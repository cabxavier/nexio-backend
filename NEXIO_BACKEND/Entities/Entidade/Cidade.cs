using Entities.Notificacao;
using System.Text.Json.Serialization;

namespace Entities.Entidade
{
    public class Cidade : Notificar
    {
        public int IdCidade { get; set; }
        public int IdEstado { get; set; }
        public string Descricao { get; set; }
        public string? CodigoIbge { get; set; }

        [JsonIgnore]
        public DateTime? DataAlteracao { get; set; }

        [JsonIgnore]
        public string? UsuarioAlteracao { get; set; }
    }
}
