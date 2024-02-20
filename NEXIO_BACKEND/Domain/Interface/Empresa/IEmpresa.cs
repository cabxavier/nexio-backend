using Domain.Interface.Generics;
using Entities.Entidade;

namespace Domain.Interface.IEmpresa
{
    public interface IEmpresa : IGenerics<Empresa>
    {
        Task<IList<Empresa>> ListarEmpresa();
    }
}
