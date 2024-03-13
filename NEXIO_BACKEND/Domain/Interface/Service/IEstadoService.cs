using Entities.Entidade;

namespace Domain.Interface.Service
{
    public interface IEstadoService
    {
        Task Insert(Estado Estado);
        Task Update(Estado Estado);
    }
}
