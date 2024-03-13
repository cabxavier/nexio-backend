using Domain.Interface.Generics;
using Entities.Entidade;

namespace Domain.Interface.ITipoEndereco
{
    public interface ITipoEndereco : IGenerics<TipoEndereco>
    {
        Task<IList<TipoEndereco>> ListarTipoEndereco();
    }
}
