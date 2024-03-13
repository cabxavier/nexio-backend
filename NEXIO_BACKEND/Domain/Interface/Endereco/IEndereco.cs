using Domain.Interface.Generics;
using Entities.Entidade;

namespace Domain.Interface.IEndereco
{
    public interface IEndereco : IGenerics<Endereco>
    {
        Task<IList<Endereco>> ListarEndereco();
    }
}
