using Entities.Notificacao;
using System.Text.Json.Serialization;

namespace Entities.Entidade
{
    public class Estado : Notificar
    {
        public int IdEstado { get; set; }
        public int IdPais { get; set; }
        public string Descricao { get; set; }
        public string Sigla { get; set; }
        public string? CodigoIbge { get; set; }

        [JsonIgnore]
        public DateTime? DataAlteracao { get; set; }

        [JsonIgnore]
        public string? UsuarioAlteracao { get; set; }
    }
}
