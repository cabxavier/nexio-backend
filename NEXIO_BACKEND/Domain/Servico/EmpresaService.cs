using Domain.Interface.IEmpresa;
using Domain.Interface.Service;
using Entities.Entidade;

namespace Domain.Servico
{
    // aqui entra a validação da classe notificar
    public class EmpresaService : IEmpresaService
    {        

        private readonly IEmpresa IEmpresa;

        public EmpresaService(IEmpresa IEmpresa)
        {
            this.IEmpresa = IEmpresa;
        }

        public async Task Insert(Empresa Empresa)
        {
            await this.IEmpresa.Insert(Empresa);
        }

        public async Task Update(Empresa Empresa)
        {
            await this.IEmpresa.Update(Empresa);
        }
    }
}
