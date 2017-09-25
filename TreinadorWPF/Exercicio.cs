using System;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Xml.Linq;

namespace TreinadorWPF {

    public enum TipoExercicio {
        Simples,
        Alternado,
        Lado
    }

    internal class Exercicio : INotifyPropertyChanged {
        public string Nome { get; set; }
        public TipoExercicio Tipo { get; set; }
        public int Descanso { get; set; }
        public string Membro { get; set; }
        public char Letra => Membro.Last();

        private int _contadorDireito;
        public int ContadorDireito {
            get => this._contadorDireito;
            set {
                if (this._contadorDireito == value) return;
                this._contadorDireito = value;
                this.NotifyPropertyChanged("ContadorDireito");
            }
        }

        private int _contadorEsquerdo;
        public int ContadorEsquerdo {
            get => this._contadorEsquerdo;
            set {
                if (this._contadorEsquerdo == value) return;
                this._contadorEsquerdo = value;
                this.NotifyPropertyChanged("ContadorEsquerdo");
            }
        }
        
        public string Lado { get; set; }
        public void LadoEsquerdo() {
            Lado = "esquerd";
        }
        public void LadoDireito() {
            Lado = "direit";
        }
        public bool IsEsquerdo => Lado == "esquerd";
        public bool IsDireito => Lado == "direit";

        public string Seta => IsEsquerdo ? "t" : "u";
        public Exercicio ProximoExercicio { get; set; }

        public bool IsSimples => Tipo == TipoExercicio.Simples;
        public bool IsEsquerdoTerminado => ContadorEsquerdo == 3;
        public bool IsDireitoTerminado => ContadorDireito == 3;
        public bool IsSerieTerminada =>
            (IsEsquerdoTerminado && IsDireitoTerminado) ||
            (IsSimples && IsEsquerdoTerminado);

        private bool IsIniciandoSerie => ContadorEsquerdo == 1 && ContadorDireito == 0;
        private int ContadorAtual => IsDireito ? ContadorDireito : ContadorEsquerdo;

        public void IncrementaContador(int incremento = 1) {
            if (IsDireito && ! IsDireitoTerminado)
                ContadorDireito += incremento;
            else
                ContadorEsquerdo += incremento;
        }

        private string Ordinal => _ordinal[ContadorAtual];
        private static readonly string[] _ordinal = { "", "primeira", "segunda", "terceira" };

        public string IniciarRepeticao() {
            switch (Tipo) {
                case TipoExercicio.Simples:
                    ContadorEsquerdo += 1;
                    break;
                case TipoExercicio.Alternado:
                    if (IsEsquerdo) {
                        ContadorEsquerdo += 1;
                    }
                    else {
                        ContadorDireito += 1;
                    }
                    break;
                case TipoExercicio.Lado:
                    if (IsEsquerdo && !IsEsquerdoTerminado) {
                        ContadorEsquerdo += 1;
                    }
                    else {
                        ContadorDireito += 1;
                    }
                    break;
                default:
                    throw new InvalidOperationException();
            }
            return (IsIniciandoSerie ? $"{Nome}. " : string.Empty) + (
                   IsSimples ? $@"Iniciar {Ordinal} repetição"
                    : $@"Iniciar {Membro} {Lado}{Letra}, {Ordinal} repetição");
        }

        public string TerminarRepeticao() {
            var frase = new StringBuilder(IsSimples
                ? $@"Terminada {Ordinal} repetição."
                : $@"Terminad{Letra} {Membro} {Lado}{Letra}, {Ordinal} repetição.");

            if (IsSerieTerminada) {
                frase.Append(" Série terminada.");
                frase.Append(ProximoExercicio == null ? @" Fim da sessão." : $" Próximo exercício {ProximoExercicio.Nome}");
            }
            else if (Tipo == TipoExercicio.Lado && IsEsquerdo && IsEsquerdoTerminado)
                frase.Append(@" Lado esquerdo terminado; mudar para lado direito.");

            switch (Tipo) {
                case TipoExercicio.Simples:
                    break;
                case TipoExercicio.Alternado:
                    Lado = IsEsquerdo ? "direit" : "esquerd";
                    break;
                case TipoExercicio.Lado:
                    if (IsEsquerdo && IsEsquerdoTerminado)
                        Lado = "direit";
                    break;
                default:
                    throw new InvalidOperationException();
            }
            return frase.ToString();
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public void NotifyPropertyChanged(string propName) {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propName));
        }

        public Exercicio() { }

        public Exercicio(XElement element) {
            Nome = element.FirstAttribute.Value;
            var tipo = element.Elements().First().Value;
            Tipo = tipo == "Alternado" ?
                        TipoExercicio.Alternado :
                  (tipo == "Lado" ?
                      TipoExercicio.Lado :
                      TipoExercicio.Simples);
            Descanso = int.Parse(element.Elements().ElementAt(1).Value);
            Membro = element.Elements().Last().Value;
            Lado = "esquerd";
        }
    }
}
