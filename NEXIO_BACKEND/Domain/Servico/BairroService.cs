using Domain.Interface.IBairro;
using Domain.Interface.Service;
using Entities.Entidade;

namespace Domain.Servico
{
    public class BairroService : IBairroService
    {
        private readonly IBairro IBairro;

        public BairroService(IBairro IBairro)
        {
            this.IBairro = IBairro;
        }

        public async Task Insert(Bairro Bairro)
        {
            await this.IBairro.Insert(Bairro);
        }

        public async Task Update(Bairro Bairro)
        {
            await this.IBairro.Update(Bairro);
        }
    }
}
