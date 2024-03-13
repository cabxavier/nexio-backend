using Domain.Interface.ICidade;
using Domain.Interface.Service;
using Entities.Entidade;

namespace Domain.Servico
{
    public class CidadeService : ICidadeService
    {
        private readonly ICidade ICidade;

        public CidadeService(ICidade ICidade)
        {
            this.ICidade = ICidade;
        }

        public async Task Insert(Cidade Cidade)
        {
            await this.ICidade.Insert(Cidade);
        }

        public async Task Update(Cidade Cidade)
        {
            await this.ICidade.Update(Cidade);
        }
    }
}
