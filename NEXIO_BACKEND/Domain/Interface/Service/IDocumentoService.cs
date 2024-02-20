using Entities.Entidade;

namespace Domain.Interface.Service
{
    public interface IDocumentoService
    {
        Task Insert(Documento Documento);
        Task Update(Documento Documento);
    }
}
