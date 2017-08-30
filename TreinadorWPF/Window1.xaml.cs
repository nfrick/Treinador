using System;
using System.Linq;
using System.Speech.Synthesis;
using System.Text;
using System.Threading;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Threading;
using System.Xml.Linq;

namespace TreinadorWPF {
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class Window1 {
        private readonly DispatcherTimer timer = new DispatcherTimer();

        private string _lado = Esquerdo;

        private readonly System.Media.SoundPlayer _playerBing =
            new System.Media.SoundPlayer(Properties.Resources.Bing_bing);

        private readonly System.Media.SoundPlayer _playerWhistle =
            new System.Media.SoundPlayer(Properties.Resources.Whistle);

        private readonly SpeechSynthesizer _speaker = new SpeechSynthesizer();
        private const string Direito = @"direit";
        private const string Esquerdo = @"esquerd";
        private const string Zero = @"0";
        private readonly string[] _ordinal = { "", "primeira", "segunda", "terceira" };

        private readonly Exercicio[] _exercicios;
        private Exercicio _exercicioAtual;
        private int _contadorSeries;
        private bool _novaSerie = true;
        private bool _autoMode = true;

        private int K = 1;

        private Brush ExercicioColor;
        private Brush NumeroAtivoColor;
        private Brush NumeroInativoColor;


        public Window1() {
            InitializeComponent();
            timer.Tick += Timer_Tick;
            timer.Interval = new TimeSpan(TimeSpan.TicksPerSecond / K);
            _speaker.SelectVoice("Microsoft Maria Desktop");
            _speaker.Volume = 100;

            var xml = XDocument.Load($@"{System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location)}\Exercicios.xml");
            if (xml.Root != null) {
                _exercicios = xml.Root.Descendants("Exercicio")
                    .Select(c => new Exercicio(c, this)).ToArray();
            }
            SliderDescanso.Maximum = 60;
            SliderDescanso.Value = 50;
            SliderDescanso.Minimum = 20;

        }

        private void Window_ContentRendered(object sender, EventArgs e) {
            ExercicioColor = TextBlockExercicio.Foreground;
            NumeroInativoColor = TextBlockContadorDireito.Foreground;
            NumeroAtivoColor = TextBlockContadorEsquerdo.Foreground;
            _exercicioAtual = _exercicios[_contadorSeries];
            MostrarExercício();
            AnunciarInicio();
        }

        private void Timer_Tick(object sender, EventArgs e) {
            try {
                if (ProgressBarDescanso.Value == ProgressBarDescanso.Maximum) throw new Exception();
                ProgressBarDescanso.Value++;
                TextSegundos.Text = $@"{ProgressBarDescanso.Value / K:00} / {ProgressBarDescanso.Maximum / K:00}";
            }

            catch (Exception) {
                timer.Stop();
                TextSegundos.Text = $@"00 / {ProgressBarDescanso.Maximum / K:00}";
                if (_contadorSeries == _exercicios.Length)
                    Close();

                if (_novaSerie) {
                    ResetaContador();
                    MostrarExercício();
                }
                else if ((SerieAlternado && ContadorEsquerdo != 0) ||
                        (SerieLado && LadoEsquerdoTerminado))
                    MudarDeLado();

                ToggleControles();
                AnunciarInicio();
            }
        }

        private void Window_KeyDown(object sender, KeyEventArgs e) {
            switch (e.Key) {
                case Key.A:
                    RadioButtonAlternado.IsChecked = true;
                    break;
                case Key.S:
                    RadioButtonSimples.IsChecked = true;
                    break;
                case Key.L:
                    RadioButtonLado.IsChecked = true;
                    break;
                case Key.M:
                    _autoMode = !_autoMode;
                    TextBlockExercicio.Foreground = _autoMode ? ExercicioColor : Brushes.AliceBlue;
                    _speaker.Speak(@"Modo automático " + (_autoMode ? "ligado" : "desligado"));
                    break;
                case Key.I:
                    ResetaContador();
                    AnunciarInicio();
                    break;
                case Key.D3:
                    SliderDescanso.Value = 30;
                    break;
                case Key.D4:
                    SliderDescanso.Value = 40;
                    break;
                case Key.D5:
                    SliderDescanso.Value = 50;
                    break;
                case Key.D6:
                    SliderDescanso.Value = 60;
                    break;
                case Key.Add:
                    _contadorSeries += _contadorSeries == _exercicios.Length - 1 ? 0 : 1;
                    _exercicioAtual = _exercicios[_contadorSeries];
                    MostrarExercício();
                    MostrarLado(false);
                    break;
                case Key.Subtract:
                    _contadorSeries -= _contadorSeries == 0 ? 0 : 1;
                    _exercicioAtual = _exercicios[_contadorSeries];
                    MostrarExercício();
                    MostrarLado(false);
                    break;
                case Key.Enter when !_autoMode:
                    AnunciarInicio();
                    break;
                case Key.Up:
                    if (ContadorAtualValor < 3) {
                        ContadorAtual.Text = (ContadorAtualValor + 1).ToString();
                        MostrarLado(false);
                    }
                    break;
                case Key.Down:
                    if (ContadorAtualValor > 0) {
                        ContadorAtual.Text = (ContadorAtualValor - 1).ToString();
                        MostrarLado(false);
                    }
                    break;
                case Key.Left:
                    _lado = Esquerdo;
                    MostrarLado(false);
                    break;
                case Key.Right:
                    _lado = Direito;
                    MostrarLado(false);
                    break;
                default:
                    if (!timer.IsEnabled)
                        Terminado();
                    break;
            }
        }

        private void ButtonTerminado_Click(object sender, RoutedEventArgs e) {
            Terminado();
        }

        private void Terminado() {
            var frase = new StringBuilder(SerieSimples
                ? $@"Terminada {Ordinal} repetição."
                : $@"Terminad{_exercicioAtual.Letra} {_exercicioAtual.Lado(_lado)}, {Ordinal} repetição.");

            if ((SerieSimples && LadoEsquerdoTerminado) || LadoDireitoTerminado) {
                frase.Append(" Série terminada.");
                _playerBing.Play();
                Thread.Sleep(1000);
                if (_autoMode) {
                    ++_contadorSeries;
                    if (_contadorSeries == _exercicios.Length) {
                        frase.Append(@" Fim da sessão.");
                        _speaker.Speak(frase.ToString());
                        Close();
                    }
                    _exercicioAtual = _exercicios[_contadorSeries];
                }
                frase.Append($" Próximo exercício {_exercicioAtual.Nome}");
                _novaSerie = true;
                ProgressBarDescanso.Maximum = 60 * K;
            }
            else if (SerieLado && LadoEsquerdoTerminado)
                frase.Append(@" Lado esquerdo terminado; mudar para lado direito.");

            _speaker.SpeakAsync(frase.ToString());

            MostrarLado(false);
            ToggleControles();
            timer.Start();
        }

        private bool SerieSimples => RadioButtonSimples.IsChecked ?? false;
        private bool SerieAlternado => RadioButtonAlternado.IsChecked ?? false;
        private bool SerieLado => RadioButtonLado.IsChecked ?? false;
        private bool LadoEsquerdoTerminado => _lado == Esquerdo && ContadorEsquerdo == 3;
        private bool LadoDireitoTerminado => _lado == Direito && ContadorDireito == 3;
        private int ContadorEsquerdo => (int.Parse(TextBlockContadorEsquerdo.Text));
        private int ContadorDireito => (int.Parse(TextBlockContadorDireito.Text));
        private int ContadorAtualValor => (int.Parse(ContadorAtual.Text));
        private TextBlock ContadorAtual => _lado == Direito ? TextBlockContadorDireito : TextBlockContadorEsquerdo;
        public string Ordinal => _ordinal[ContadorAtualValor];

        private void ToggleControles() {
            ProgressBarDescanso.Value = 0;
            ButtonTerminado.Visibility = ButtonTerminado.Visibility == Visibility.Visible ? Visibility.Hidden : Visibility.Visible;
            TextSegundos.Visibility = TextSegundos.Visibility == Visibility.Visible ? Visibility.Hidden : Visibility.Visible;
            GroupBoxTipo.IsEnabled = !GroupBoxTipo.IsEnabled;
            SliderDescanso.IsEnabled = !SliderDescanso.IsEnabled;
        }

        private void AnunciarInicio() {
            //MostrarExercício();
            var frase = _novaSerie ? $"{_exercicioAtual.Nome}. " : "";
            MostrarLado(true);
            _speaker.Speak(frase
                + (SerieSimples
                ? $@"Iniciar {Ordinal} repetição"
                : $@"Iniciar {_exercicioAtual.Lado(_lado)}, {Ordinal} repetição"));
            _playerWhistle.Play();
            _novaSerie = false;
        }

        private void MostrarExercício() {
            TextBlockExercicio.Text = _exercicioAtual.Nome;
            SliderDescanso.Value = _exercicioAtual.Descanso;
            _exercicioAtual.Tipo.IsChecked = true;
            SetaDescanso();
        }

        private void MudarDeLado() {
            _lado = _lado == Esquerdo ? Direito : Esquerdo;
        }

        private void MostrarLado(bool mostrar) {
            if (mostrar)
                ContadorAtual.Text = (ContadorAtualValor + 1).ToString();
            TextBlockContadorEsquerdo.Foreground = mostrar && _lado == Esquerdo ? NumeroAtivoColor : NumeroInativoColor; //Brushes.Yellow : Brushes.White;
            TextBlockContadorDireito.Foreground = mostrar && _lado == Direito ? NumeroAtivoColor : NumeroInativoColor; // Brushes.Yellow : Brushes.White;
            TextBlockSeta.Text = _lado == Esquerdo ? "t" : "u";
            TextBlockSeta.Visibility = mostrar ? Visibility.Visible : Visibility.Hidden;
        }

        private void ResetaContador() {
            TextBlockContadorEsquerdo.Text = Zero;
            TextBlockContadorDireito.Text = Zero;
            _lado = Esquerdo;
        }

        private void SliderDescanso_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e) {
            SetaDescanso();
        }

        private void SetaDescanso() {
            TextBlockDescanso.Text = $@"Descanso: {SliderDescanso.Value:00}s";
            ProgressBarDescanso.Maximum = SliderDescanso.Value * K;
            TextSegundos.Text = $@"00 / {ProgressBarDescanso.Maximum / K:00}";
        }

        private void RadioButton_Checked(object sender, RoutedEventArgs e) {
            var rb = sender as RadioButton;
            if (rb == null || !(rb.IsChecked ?? false)) return;

            //var counterX = RadioButtonSimples.IsChecked ? 200 : -22;
            //var setaX = RadioButtonSimples.IsChecked ? 558 : 336;
            //TextBlockContadorEsquerdo.Margin = = new Thickness(;
            //TextBlockSeta.Location = new Point(setaX, TextBlockSeta.Location.Y);

            //TextBlockContadorDireito.Visible = !RadioButtonSimples.IsChecked;
        }
    }
}
