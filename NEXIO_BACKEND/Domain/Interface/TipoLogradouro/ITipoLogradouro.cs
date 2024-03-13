using Domain.Interface.Generics;
using Entities.Entidade;

namespace Domain.Interface.ITipoLogradouro
{
    public interface ITipoLogradouro : IGenerics<TipoLogradouro>
    {
        Task<IList<TipoLogradouro>> ListarTipoLogradouro();
    }
}
