using Entities.Notificacao;
using System.Text.Json.Serialization;

namespace Entities.Entidade
{
    public class Pessoa : Notificar
    {
        public int IdPessoa { get; set; }
        public int? IdUsuario { get; set; }
        public string Codigo { get; set; }
        public string? CodigoInterno { get; set; }
        public string RazaoSocial { get; set; }
        public string NomeFantasia { get; set; }
        public string? Cnpj { get; set; }
        public string? Cpf { get; set; }
        public string? EmailPrincipal { get; set; }
        public string? EmailSecundario { get; set; }
        public bool Cliente { get; set; }
        public bool Funcionario { get; set; }
        public bool Vendedor { get; set; }
        public bool Transportadora { get; set; }
        public bool Fornecedor { get; set; }
        public bool Representante { get; set; }
        public bool ConsumidorFinal { get; set; }
        public bool ContribuinteIcms { get; set; }
        public bool IsentoIpi { get; set; }
        public bool Ativo { get; set; }

        [JsonIgnore]
        public DateTime? DataAlteracao { get; set; }

        [JsonIgnore]
        public string? UsuarioAlteracao { get; set; }
    }
}
