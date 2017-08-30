using System;
using System.Drawing;
using System.Drawing.Text;
using System.Linq;
using System.Windows.Forms;
using System.Speech.Synthesis;
using System.Threading;
using System.Xml.Linq;

namespace Treinador {
    public partial class Form1 : Form {

        private string _lado = Esquerdo;

        private readonly System.Media.SoundPlayer _playerBing =
            new System.Media.SoundPlayer(Properties.Resources.Bing_bing);

        private readonly System.Media.SoundPlayer _playerWhistle =
            new System.Media.SoundPlayer(Properties.Resources.Whistle);

        private readonly SpeechSynthesizer _speaker = new SpeechSynthesizer();
        private const string Direito = @"direit";
        private const string Esquerdo = @"esquerd";
        private const string Zero = @"0";
        private const string Tres = @"3";
        private readonly string[] _ordinal = { "", "primeira", "segunda", "terceira" };

        private readonly Exercicio[] _exercicios;
        private Exercicio _exercicioAtual;
        private int _contador = 0; 
        private bool _novaSerie = true;
        private bool _autoMode = true;

        public Form1() {
            InitializeComponent();
            _speaker.SelectVoice("Microsoft Maria Desktop");
            _speaker.Volume = 100;

            #region Exercicios (hard-coded)
            //_exercicios = new[] {
            //    new Exercicio {Nome = "Elevação da perna", Tipo = radioButtonAlternado, Descanso = 50},
            //    new Exercicio {Nome = "Extensão do joelho", Tipo = radioButtonAlternado, Descanso = 50},
            //    new Exercicio {Nome = "Adução e abdução dos joelhos", Tipo = radioButtonSimples, Descanso = 50},
            //    new Exercicio {Nome = "Ponte", Tipo = radioButtonSimples, Descanso = 50},
            //    new Exercicio {Nome = "Rosca triceps", Tipo = radioButtonLado, Descanso = 50},
            //    new Exercicio {Nome = "Elevação lateral da perna", Tipo = radioButtonLado, Descanso = 50},
            //    new Exercicio {Nome = "Flexão do joelho", Tipo = radioButtonAlternado, Descanso = 30},
            //    new Exercicio {Nome = "Extensão da perna sentado", Tipo = radioButtonAlternado, Descanso = 50},
            //    new Exercicio {Nome = "Afastamento das mãos", Tipo = radioButtonSimples, Descanso = 50},
            //    new Exercicio {Nome = "Rosca biceps", Tipo = radioButtonLado, Descanso = 50},
            //    new Exercicio {Nome = "Rosca pulso", Tipo = radioButtonSimples, Descanso = 50}
            //};
            #endregion

            var xml = XDocument.Load($@"{System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location)}\Exercicios.xml");
            if (xml.Root != null) {
                _exercicios = xml.Root.Descendants("Exercicio")
                    .Select(c => new Exercicio(c, this)).ToArray();
            }
            _exercicioAtual = _exercicios[0];
        }

        private void Form1_Shown(object sender, EventArgs e) {
            AnunciarInicio();
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e) {
            e.SuppressKeyPress = true;
            switch (e.KeyCode) {
                case Keys.A:
                    radioButtonAlternado.Checked = true;
                    break;
                case Keys.S:
                    radioButtonSimples.Checked = true;
                    break;
                case Keys.L:
                    radioButtonLado.Checked = true;
                    break;
                case Keys.M:
                    _autoMode = !_autoMode;
                    labelExercicio.ForeColor = _autoMode ? Color.DarkRed : Color.Black;
                    _speaker.Speak(@"Modo automático " + (_autoMode ? "ligado" : "desligado"));
                    break;
                case Keys.I:
                    ResetaContador();
                    AnunciarInicio();
                    break;
                case Keys.D3:
                    trackBar1.Value = 30;
                    break;
                case Keys.D4:
                    trackBar1.Value = 40;
                    break;
                case Keys.D5:
                    trackBar1.Value = 50;
                    break;
                case Keys.D6:
                    trackBar1.Value = 60;
                    break;
                case Keys.Add:
                    _contador += _contador == _exercicios.Length - 1 ? 0 : 1;
                    MostrarExercício();
                    break;
                case Keys.Subtract:
                    _contador -= _contador == 0 ? 0 : 1;
                    MostrarExercício();
                    break;
                case Keys.Enter when !_autoMode:
                    AnunciarInicio();
                    break;
                default:
                    if (!timer1.Enabled)
                        Terminado();
                    break;
            }
        }

        private void buttonTerminado_Click(object sender, EventArgs e) {
            Terminado();
        }

        private void Terminado() {
            var frase = radioButtonSimples.Checked
                ? $@"Terminada {Ordinal} repetição."
                : $@"Terminad{_exercicioAtual.Letra} {_exercicioAtual.Lado(_lado)}, {Ordinal} repetição.";

            if ((labelEsquerdoCounter.Text == Tres && radioButtonSimples.Checked) ||
                labelDireitoCounter.Text == Tres) {
                _speaker.Speak(frase + " Série terminada.");
                _playerBing.Play();
                Thread.Sleep(3000);
                if (_autoMode) {
                    ++_contador;
                    _exercicioAtual = _exercicios[_contador];
                }
                _speaker.Speak(_contador == _exercicios.Length
                    ? "Fim da sessão"
                    : "Próximo exercício " + _exercicios[_contador].Nome);
                _novaSerie = true;
            }
            else if (radioButtonLado.Checked && _lado == Esquerdo && LabelContador == 3)
                _speaker.SpeakAsync(frase + @" Lado esquerdo terminado; mudar para lado direito.");

            else
                _speaker.SpeakAsync(frase);

            MostrarLado(false);
            ToggleControles();
            timer1.Start();
        }

        private int LabelContador => (int.Parse(ContadorAtual.Text));

        private Label ContadorAtual => _lado == Direito ? labelDireitoCounter : labelEsquerdoCounter;

        public string Ordinal => _ordinal[LabelContador];

        private void ToggleControles() {
            progressBar1.Value = 0;
            buttonTerminado.Visible = !buttonTerminado.Visible;
            groupBox1.Enabled = !groupBox1.Enabled;
            trackBar1.Enabled = !trackBar1.Enabled;
        }

        private void timer1_Tick(object sender, EventArgs e) {
            try {
                progressBar1.Value++;
            }
            catch (ArgumentOutOfRangeException) {
                timer1.Stop();
                if (_contador == _exercicios.Length)
                    this.Close();

                if(_novaSerie)
                    ResetaContador();

                else if (radioButtonAlternado.Checked && labelEsquerdoCounter.Text != Zero)
                    MudarDeLado();

                else if (radioButtonLado.Checked && _lado == Esquerdo && labelEsquerdoCounter.Text == Tres)
                        MudarDeLado();

                ToggleControles();
                AnunciarInicio();
            }
        }

        private void AnunciarInicio() {
            MostrarExercício();
            var frase = _novaSerie ? _exercicioAtual.Nome : "";
            MostrarLado(true);
            _speaker.Speak(frase
                + (radioButtonSimples.Checked
                ? $@"Iniciar {Ordinal} repetição"
                : $@"Iniciar {_exercicioAtual.Lado(_lado)}, {Ordinal} repetição"));
            _playerWhistle.Play();
            _novaSerie = false;
        }

        private void MostrarExercício() {
            labelExercicio.Text = _exercicioAtual.Nome.ToUpper();
            trackBar1.Value = _exercicioAtual.Descanso;
            _exercicioAtual.Tipo.Checked = true;
            SetaDescanso();
        }
        
        private void MudarDeLado() {
            _lado = _lado == Esquerdo ? Direito : Esquerdo;
        }

        private void MostrarLado(bool mostrar) {
            if (mostrar)
                ContadorAtual.Text = (LabelContador + 1).ToString();
            labelEsquerdoCounter.ForeColor = mostrar && _lado == Esquerdo ? Color.Yellow : Color.White;
            labelDireitoCounter.ForeColor = mostrar && _lado == Direito ? Color.Yellow : Color.White;
            labelSeta.Text = _lado == Esquerdo ? "ç" : "è";
            labelSeta.Visible = mostrar;
            Refresh();
        }

        private void ResetaContador() {
            labelEsquerdoCounter.Text = Zero;
            labelDireitoCounter.Text = Zero;
            _lado = Esquerdo;
        }

        private void trackBar1_Scroll(object sender, EventArgs e) {
            SetaDescanso();
        }

        private void SetaDescanso() {
            labelDescanso.Text = $@"Descanso: {trackBar1.Value}s";
            progressBar1.Maximum = trackBar1.Value * 20;
        }

        private void radioButton_CheckedChanged(object sender, EventArgs e) {
            var rb = sender as RadioButton;
            if (rb == null || !rb.Checked) return;

            var counterX = radioButtonSimples.Checked ? 200 : -22;
            var setaX = radioButtonSimples.Checked ? 558 : 336;
            labelEsquerdoCounter.Location = new Point(counterX, labelEsquerdoCounter.Location.Y);
            labelSeta.Location = new Point(setaX, labelSeta.Location.Y);

            labelDireitoCounter.Visible = !radioButtonSimples.Checked;
        }
    }
}
