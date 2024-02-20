using Entities.Entidade;

namespace Domain.Interface.Service
{
    public interface IUsuarioService
    {
        Task Insert(Usuario Usuario);
        Task Update(Usuario Usuario);
    }
}
