using Domain.Interface.Generics;
using Entities.Entidade;

namespace Domain.Interface.IPais
{
    public interface IPais : IGenerics<Pais>
    {
        Task<IList<Pais>> ListarPais();
    }
}
