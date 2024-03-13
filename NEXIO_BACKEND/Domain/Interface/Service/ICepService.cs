using Entities.Entidade;

namespace Domain.Interface.Service
{
    public interface ICepService
    {
        Task Insert(Cep Cep);
        Task Update(Cep Cep);
    }
}
