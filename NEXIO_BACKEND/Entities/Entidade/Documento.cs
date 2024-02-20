using Entities.Notificacao;

namespace Entities.Entidade
{
    public class Documento : Notificar
    {
        public int IdDocumento { get; set; }
        public int IdEmpresa { get; set; }
    }
}
