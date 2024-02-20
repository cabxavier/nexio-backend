using Domain.Interface.Generics;
using Entities.Entidade;

namespace Domain.Interface.IDocumento
{
    public interface IDocumento : IGenerics<Documento>
    {
        Task<IList<Documento>> ListarDocumento();
        Task<IList<Documento>> ListarDocumentoPorIdEmpresa(int IdEmpresa);
    }
}
