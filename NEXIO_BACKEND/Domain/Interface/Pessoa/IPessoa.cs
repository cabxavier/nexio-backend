using Domain.Interface.Generics;
using Entities.Entidade;

namespace Domain.Interface.IPessoa
{
    public interface IPessoa : IGenerics<Pessoa>
    {
        Task<IList<Pessoa>> ListarPessoa();
    }
}
