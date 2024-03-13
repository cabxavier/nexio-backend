using Domain.Interface.Generics;
using Entities.Entidade;

namespace Domain.Interface.ILogradouro
{
    public interface ILogradouro : IGenerics<Logradouro>
    {
        Task<IList<Logradouro>> ListarLogradouro();
    }
}
