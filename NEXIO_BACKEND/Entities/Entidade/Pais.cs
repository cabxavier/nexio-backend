using Entities.Notificacao;
using System.Text.Json.Serialization;

namespace Entities.Entidade
{
    public class Pais : Notificar
    {
        public int IdPais { get; set; }
        public string Descricao { get; set; }
        public string? Ddi { get; set; }
        public string? CodigoBacen { get; set; }

        [JsonIgnore]
        public DateTime? DataAlteracao { get; set; }

        [JsonIgnore]
        public string? UsuarioAlteracao { get; set; }
    }
}
