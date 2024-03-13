using Entities.Notificacao;
using System.Text.Json.Serialization;

namespace Entities.Entidade
{
    public class Usuario : Notificar
    {
        public int IdUsuario { get; set; }
        public string Cpf { get; set; }
        public string Nome { get; set; }
        public string UsuarioLogin { get; set; }
        public byte[] Senha { get; set; }
        public bool AlterarSenhaProximoLogin { get; set; }
        public DateTime DataLimiteAcesso { get; set; }
        public bool Ativo { get; set; }

        [JsonIgnore]
        public DateTime? DataAlteracao { get; set; }

        [JsonIgnore]
        public string? UsuarioAlteracao { get; set; }
    }
}
