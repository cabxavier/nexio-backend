using Entities.Notificacao;
using System.Text.Json.Serialization;

namespace Entities.Entidade
{
    public class TipoLogradouro : Notificar
    {
        public int IdTipoLogradouro { get; set; }
        public string Descricao { get; set; }
        public string? Sigla { get; set; }

        [JsonIgnore]
        public DateTime? DataAlteracao { get; set; }

        [JsonIgnore]
        public string? UsuarioAlteracao { get; set; }
    }
}
