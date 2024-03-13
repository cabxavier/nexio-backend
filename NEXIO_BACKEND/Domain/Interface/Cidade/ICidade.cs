using Domain.Interface.Generics;
using Entities.Entidade;

namespace Domain.Interface.ICidade
{
    public interface ICidade : IGenerics<Cidade>
    {
        Task<IList<Cidade>> ListarCidade();
    }
}
