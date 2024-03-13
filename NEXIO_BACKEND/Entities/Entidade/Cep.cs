using Entities.Notificacao;
using System.Text.Json.Serialization;

namespace Entities.Entidade
{
    public class Cep : Notificar
    {
       public int IdCep { get; set; }
       public int IdCidade { get; set; }
        public int IdBairro { get; set; }
        public int IdLogradouro { get; set; }
        public string CepNumero { get; set; }
        public string? Complemento { get; set; }

        [JsonIgnore]
        public DateTime? DataAlteracao { get; set; }

        [JsonIgnore]
        public string? UsuarioAlteracao { get; set; }
    }
}
