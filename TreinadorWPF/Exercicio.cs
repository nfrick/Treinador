using System.Linq;
using System.Windows.Controls;
using System.Xml.Linq;

namespace TreinadorWPF {
    class Exercicio {
        public string Nome { get; set; }
        public RadioButton Tipo { get; set; }
        public int Descanso { get; set; }
        public string Membro { get; set; }
        public string Lado(string lado) => $@"{Membro} {lado}{Letra}";
        public char Letra => Membro.Last();

        public Exercicio() { }

        public Exercicio(XElement element, Window1 form) {
            Nome = element.FirstAttribute.Value;
            var tipo = element.Elements().First().Value;
            Tipo = tipo == "Alternado" ?
                        form.RadioButtonAlternado :
                  (tipo == "Lado" ?
                        form.RadioButtonLado :
                        form.RadioButtonSimples);

            Descanso = int.Parse(element.Elements().ElementAt(1).Value);
            Membro = element.Elements().Last().Value;
        }
    }
}
