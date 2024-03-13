using Entities.Entidade;

namespace Domain.Interface.Service
{
    public interface ICidadeService
    {
        Task Insert(Cidade Cidade);
        Task Update(Cidade Cidade);
    }
}
