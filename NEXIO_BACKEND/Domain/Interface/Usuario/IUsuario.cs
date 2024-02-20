using Domain.Interface.Generics;
using Entities.Entidade;

namespace Domain.Interface.IUsuario
{
    public interface IUsuario : IGenerics<Usuario>
    {
        Task<IList<Usuario>> ListarUsuario();
    }
}
