using Domain.Interface.IPais;
using Domain.Interface.Service;
using Entities.Entidade;

namespace Domain.Servico
{
    public class PaisService : IPaisService
    {
        private readonly IPais IPais;

        public PaisService(IPais IPais)
        {
            this.IPais = IPais;
        }

        public async Task Insert(Pais Pais)
        {
            await this.IPais.Insert(Pais);
        }

        public async Task Update(Pais Pais)
        {
            await this.IPais.Update(Pais);
        }
    }
}
