using Domain.Interface.IDocumento;
using Domain.Interface.Service;
using Entities.Entidade;

namespace Domain.Servico
{
    // aqui entra a validação da classe notificar
    public class DocumentoService : IDocumentoService
    {
        private readonly IDocumento IDocumento;

        public DocumentoService(IDocumento IDocumento)
        {
            this.IDocumento = IDocumento;
        }

        public async Task Insert(Documento Documento)
        {
            await this.IDocumento.Insert(Documento);
        }

        public async Task Update(Documento Documento)
        {
           await this.IDocumento.Update(Documento);
        }
    }
}
