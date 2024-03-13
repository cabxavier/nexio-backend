using Entities.Entidade;

namespace Domain.Interface.Service
{
    public interface IPaisService
    {
        Task Insert(Pais Pais);
        Task Update(Pais Pais);
    }
}
