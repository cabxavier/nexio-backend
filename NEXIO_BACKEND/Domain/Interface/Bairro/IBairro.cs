using Domain.Interface.Generics;
using Entities.Entidade;

namespace Domain.Interface.IBairro
{
    public interface IBairro : IGenerics<Bairro>
    {
        Task<IList<Bairro>> ListarBairro();
    }
}
