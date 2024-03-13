using Entities.Notificacao;
using System.Text.Json.Serialization;

namespace Entities.Entidade
{
    public class TipoEndereco : Notificar
    {
        public int IdTipoEndereco { get; set; }
        public string Descricao { get; set; }
        public bool Principal { get; set; }
        public bool Entrega { get; set; }
        public bool Cobranca { get; set; }

        [JsonIgnore]
        public DateTime? DataAlteracao { get; set; }

        [JsonIgnore]
        public string? UsuarioAlteracao { get; set; }
    }
}
