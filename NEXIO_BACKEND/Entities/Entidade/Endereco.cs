using Entities.Notificacao;
using System.Text.Json.Serialization;

namespace Entities.Entidade
{
    public class Endereco : Notificar
    {
        public int IdEndereco { get; set; }
        public int IdTipoEndereco { get; set; }
        public int IdCep { get; set; }
        public int IdPessoa { get; set; }
        public string Numero { get; set; }
        public string? Telefone { get; set; }
        public string? Celular { get; set; }
        public string? Complemento { get; set; }
        public string? Observacao { get; set; }
        public bool Ativo { get; set; }

        [JsonIgnore]
        public DateTime? DataAlteracao { get; set; }

        [JsonIgnore]
        public string? UsuarioAlteracao { get; set; }
    }
}
