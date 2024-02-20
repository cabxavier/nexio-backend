using Entities.Entidade;

namespace Domain.Interface.Service
{
    public interface IEmpresaService
    {
        Task Insert(Empresa Empresa);
        Task Update(Empresa Empresa);
    }
}
