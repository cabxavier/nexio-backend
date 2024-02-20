using Entities.Entidade;

namespace Domain.Interface.Service
{
    public interface IPessoaService
    {
        Task Insert(Pessoa Pessoa);
        Task Update(Pessoa Pessoa);
    }
}
