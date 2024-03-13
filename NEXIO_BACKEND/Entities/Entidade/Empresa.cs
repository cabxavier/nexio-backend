using Entities.Notificacao;
using System.Text.Json.Serialization;

namespace Entities.Entidade
{
    public class Empresa : Notificar
    {
        public int IdEmpresa { get; set; }
        public int IdPessoa { get; set; }
        public string Nome { get; set; }
        public string Cnpj { get; set; }
        public string? InscricaoMunicipal { get; set; }
        public string? InscricaoEstadual { get; set; }
        public string Sigla { get; set; }

        [JsonIgnore]
        public DateTime? DataAlteracao { get; set; }

        [JsonIgnore]
        public string? UsuarioAlteracao { get; set; }
    }
}
