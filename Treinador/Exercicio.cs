using System.Linq;
using System.Windows.Forms;
using System.Xml.Linq;

namespace Treinador {
    public class Exercicio {
        public string Nome { get; set; }
        public RadioButton Tipo { get; set; }
        public int Descanso { get; set; }
        public string Membro { get; set; }
        public string Lado(string lado) => $@"{Membro} {lado}{Membro.Last()}";
        public char Letra => Membro.Last();

        public Exercicio() { }

        public Exercicio(XElement element, Form1 form) {
            Nome = element.FirstAttribute.Value;
            var tipo = element.Elements().First().Value;
            Tipo = tipo == "Alternado" ?
                        form.radioButtonAlternado :
                  (tipo == "Lado" ? 
                        form.radioButtonLado : 
                        form.radioButtonSimples);

            Descanso = int.Parse(element.Elements().ElementAt(1).Value);
            Membro = element.Elements().Last().Value;
        }
    }
}