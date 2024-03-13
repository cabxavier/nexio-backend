using Entities.Entidade;

namespace Domain.Interface.Service
{
    public interface IEnderecoService
    {
        Task Insert(Endereco Endereco);
        Task Update(Endereco Endereco);
    }
}
