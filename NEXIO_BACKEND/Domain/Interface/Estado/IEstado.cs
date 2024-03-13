using Domain.Interface.Generics;
using Entities.Entidade;

namespace Domain.Interface.IEstado
{
    public interface IEstado : IGenerics<Estado>
    {
        Task<IList<Estado>> ListarEstado();
    }
}
