using Entities.Entidade;

namespace Domain.Interface.Service
{
    public interface ITipoEnderecoService
    {
        Task Insert(TipoEndereco TipoEndereco);
        Task Update(TipoEndereco TipoEndereco);
    }
}
