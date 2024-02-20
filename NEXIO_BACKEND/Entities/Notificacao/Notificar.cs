using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Entities.Notificacao
{
    public class Notificar
    {
        public Notificar() { }

        [JsonIgnore]
        [NotMapped]
        public string NomePropriedade { get; set; }

        [JsonIgnore]
        [NotMapped]
        public string Mensagem { get; set; }

        [JsonIgnore]
        [NotMapped]
        public List<Notificar> ListNotificar { get; set; }

        public bool ValidarPropriedadeString(string valor, string NomePropriedade)
        {
            if (string.IsNullOrWhiteSpace(valor) || string.IsNullOrWhiteSpace(NomePropriedade))
            {
                this.ListNotificar.Add(new Notificar()
                {
                    Mensagem = "Campo Obrigatório",
                    NomePropriedade = NomePropriedade
                });

                return false;
            }

            return true;
        }

        public bool ValidarPropriedadeInt(int valor, string NomePropriedade)
        {
            if (valor < 1 || string.IsNullOrWhiteSpace(NomePropriedade))
            {
                this.ListNotificar.Add(new Notificar()
                {
                    Mensagem = "Campo Obrigatório",
                    NomePropriedade = NomePropriedade
                });

                return false;
            }

            return true;
        }
    }
}
