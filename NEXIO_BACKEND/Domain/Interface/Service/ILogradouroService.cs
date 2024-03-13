using Entities.Entidade;

namespace Domain.Interface.Service
{
    public interface ILogradouroService
    {
        Task Insert(Logradouro Logradouro);
        Task Update(Logradouro Logradouro);
    }
}
