using Entities.Entidade;

namespace Domain.Interface.Service
{
    public interface IBairroService
    {
        Task Insert(Bairro Bairro);
        Task Update(Bairro Bairro);
    }
}
