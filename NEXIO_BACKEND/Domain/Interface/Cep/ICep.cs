using Domain.Interface.Generics;
using Entities.Entidade;

namespace Domain.Interface.ICep
{
    public interface ICep : IGenerics<Cep>
    {
        Task<IList<Cep>> ListarCep();
    }
}
