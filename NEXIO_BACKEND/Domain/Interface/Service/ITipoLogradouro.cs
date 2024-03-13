using Entities.Entidade;

namespace Domain.Interface.Service
{
    public interface ITipoLogradouroService
    {
        Task Insert(TipoLogradouro TipoLogradouro);
        Task Update(TipoLogradouro TipoLogradouro);
    }
}
