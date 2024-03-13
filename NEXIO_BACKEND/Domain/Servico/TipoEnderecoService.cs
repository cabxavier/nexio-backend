using Domain.Interface.ITipoEndereco;
using Domain.Interface.Service;
using Entities.Entidade;

namespace Domain.Servico
{
    public class TipoEnderecoService : ITipoEnderecoService
    {
        private readonly ITipoEndereco ITipoEndereco;

        public TipoEnderecoService(ITipoEndereco ITipoEndereco)
        {
            this.ITipoEndereco = ITipoEndereco;
        }

        public async Task Insert(TipoEndereco TipoEndereco)
        {
            await this.ITipoEndereco.Insert(TipoEndereco);
        }

        public async Task Update(TipoEndereco TipoEndereco)
        {
            await this.ITipoEndereco.Update(TipoEndereco);
        }
    }
}
