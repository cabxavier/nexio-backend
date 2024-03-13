using Domain.Interface.ICep;
using Domain.Interface.Service;
using Entities.Entidade;

namespace Domain.Servico
{
    public class CepService : ICepService
    {
        private readonly ICep ICep;

        public CepService(ICep ICep)
        {
            this.ICep = ICep;
        }

        public async Task Insert(Cep Cep)
        {
            await this.ICep.Insert(Cep);
        }

        public async Task Update(Cep Cep)
        {
            await this.ICep.Update(Cep);
        }
    }
}
