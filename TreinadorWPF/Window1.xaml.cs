using System;
using System.Collections.Generic;
using System.Linq;
using System.Speech.Synthesis;
using System.Threading;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
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
        private readonly System.Media.SoundPlayer _playerBing =
            new System.Media.SoundPlayer(Properties.Resources.Bing_bing);
        private readonly System.Media.SoundPlayer _playerWhistle =
            new System.Media.SoundPlayer(Properties.Resources.Whistle);
        private readonly SpeechSynthesizer _speaker = new SpeechSynthesizer();

        private readonly CollectionView _exercicios;
        private bool _autoMode = true;

        private const int K = 1;

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
                _exercicios = new CollectionView(xml.Root.Descendants("Exercicio")
                    .Select(c => new Exercicio(c)).ToArray());
            }
            for (var i = 0; i < _exercicios.Count - 1; i++) {
                ((Exercicio)_exercicios.GetItemAt(i)).ProximoExercicio = (Exercicio)_exercicios.GetItemAt(i + 1);
            }
            this.DataContext = _exercicios;
        }

        private void Window_ContentRendered(object sender, EventArgs e) {
            ExercicioColor = TextBlockExercicio.Foreground;
            NumeroInativoColor = TextBlockContadorDireito.Foreground;
            NumeroAtivoColor = TextBlockContadorEsquerdo.Foreground;
            AnunciarInicio();
        }

        private void Timer_Tick(object sender, EventArgs e) {
            try {
                if (ProgressBarDescanso.Value == ProgressBarDescanso.Maximum)
                    throw new Exception();
                ProgressBarDescanso.Value++;
            }
            catch (Exception) {

                timer.Stop();
                if (_autoMode && ((Exercicio)_exercicios.CurrentItem).IsSerieTerminada) {
                    _exercicios.MoveCurrentToNext();
                }
                ToggleControles();
                AnunciarInicio();
            }
        }

        private void Window_KeyDown(object sender, KeyEventArgs e) {
            var exercicio = (Exercicio)_exercicios.CurrentItem;
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
                    _exercicios.MoveCurrentToNext();
                    if (_exercicios.IsCurrentAfterLast)
                        _exercicios.MoveCurrentToLast();
                    break;
                case Key.Subtract:
                    _exercicios.MoveCurrentToPrevious();
                    if (_exercicios.IsCurrentBeforeFirst)
                        _exercicios.MoveCurrentToFirst();
                    break;
                case Key.Enter when !_autoMode:
                    AnunciarInicio();
                    break;
                case Key.Up:
                    exercicio.IncrementaContador();
                    break;
                case Key.Down:
                    exercicio.IncrementaContador(-1);
                    break;
                case Key.Left:
                    exercicio.LadoEsquerdo();
                    MostrarLado(false);
                    break;
                case Key.Right:
                    exercicio.LadoDireito();
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
            var exercicio = (Exercicio)_exercicios.CurrentItem;
            if (exercicio.IsSerieTerminada) {
                _playerBing.Play();
                Thread.Sleep(1000);
            }
            _speaker.SpeakAsync(exercicio.TerminarRepeticao());

            if (exercicio.IsSerieTerminada) {
                if (_exercicios.CurrentPosition == _exercicios.Count - 1) {
                    Close();
                }
                SliderDescanso.Value = 60;
            }
            ToggleControles();
            timer.Start();
        }

        private void ToggleControles() {
            ProgressBarDescanso.Value = 0;
            ButtonTerminado.Visibility = ButtonTerminado.Visibility == Visibility.Visible ? Visibility.Hidden : Visibility.Visible;
            TextSegundos.Visibility = TextSegundos.Visibility == Visibility.Visible ? Visibility.Hidden : Visibility.Visible;
            GroupBoxTipo.IsEnabled = !GroupBoxTipo.IsEnabled;
            SliderDescanso.IsEnabled = !SliderDescanso.IsEnabled;
        }

        private void AnunciarInicio() {
            var exercicio = (Exercicio)_exercicios.CurrentItem;
            _speaker.Speak(exercicio.IniciarRepeticao());
            _playerWhistle.Play();
            MostrarLado(true);
        }


        private void MostrarLado(bool mostrar) {
            var exercicio = (Exercicio)_exercicios.CurrentItem;
            TextBlockContadorEsquerdo.Foreground = mostrar && exercicio.IsEsquerdo ? NumeroAtivoColor : NumeroInativoColor; //Brushes.Yellow : Brushes.White;
            TextBlockContadorDireito.Foreground = mostrar && exercicio.IsDireito ? NumeroAtivoColor : NumeroInativoColor; // Brushes.Yellow : Brushes.White;
            TextBlockSeta.Text = exercicio.Seta;
            TextBlockSeta.Visibility = mostrar ? Visibility.Visible : Visibility.Hidden;
        }

        private void RadioButton_Checked(object sender, RoutedEventArgs e) {
            var rb = sender as RadioButton;
            if (rb == null || !(rb.IsChecked ?? false)) return;
        }
    }

    public class RadioButtonCheckedConverter : IValueConverter {
        public object Convert(object value, Type targetType, object parameter,
            System.Globalization.CultureInfo culture) {
            return value.Equals(parameter);
        }

        public object ConvertBack(object value, Type targetType, object parameter,
            System.Globalization.CultureInfo culture) {
            return value.Equals(true) ? parameter : Binding.DoNothing;
        }
    }
}
