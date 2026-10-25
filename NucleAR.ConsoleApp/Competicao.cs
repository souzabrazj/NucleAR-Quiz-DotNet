using System.Text.Json.Serialization;

namespace NucleAR.ConsoleApp
{
    public class Competicao
    {
        public int Id { get; set; }
        public string Nome { get; set; } = string.Empty;
        public string Categoria { get; set; } = string.Empty; // Ex: Medicina, Agricultura, Indústria, Geração de Energia
        public int QuantidadeQuestoes { get; set; } // De 4 a 10
        public string Premiacao { get; set; } = string.Empty; // Ex: Boné, Bottom, Adesivo da Amazul
        public DateTime DataEncerramento { get; set; }

        // Validação básica dos atributos e Regra de Negócio
        public bool Validar(out string mensagemErro)
        {
            mensagemErro = string.Empty;

            if (string.IsNullOrWhiteSpace(Nome))
            {
                mensagemErro = "O nome da competição não pode ser vazio.";
                return false;
            }

            if (string.IsNullOrWhiteSpace(Categoria))
            {
                mensagemErro = "A categoria temática deve ser informada.";
                return false;
            }

            if (QuantidadeQuestoes < 4 || QuantidadeQuestoes > 10)
            {
                mensagemErro = "A quantidade de questões deve estar entre 4 e 10 para calibrar o temporizador proporcional.";
                return false;
            }

            if (DataEncerramento <= DateTime.Now)
            {
                mensagemErro = "A data de encerramento deve ser futura.";
                return false;
            }

            return true;
        }
    }
}