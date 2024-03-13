using Entities.Notificacao;
using System.Text.Json.Serialization;

namespace Entities.Entidade
{
    public class Logradouro : Notificar
    {
        public int IdLogradouro { get; set; }
        public int IdTipoLogradouro { get; set; }
        public string Descricao { get; set; }

        [JsonIgnore]
        public DateTime? DataAlteracao { get; set; }

        [JsonIgnore]
        public string? UsuarioAlteracao { get; set; }
    }
}
