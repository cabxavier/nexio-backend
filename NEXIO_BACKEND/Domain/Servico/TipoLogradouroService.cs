using Domain.Interface.ITipoLogradouro;
using Domain.Interface.Service;
using Entities.Entidade;

namespace Domain.Servico
{
    public class TipoLogradouroService : ITipoLogradouroService
    {
        private readonly ITipoLogradouro ITipoLogradouro;

        public TipoLogradouroService(ITipoLogradouro ITipoLogradouro)
        {
            this.ITipoLogradouro = ITipoLogradouro;
        }

        public async Task Insert(TipoLogradouro TipoLogradouro)
        {
            await this.ITipoLogradouro.Insert(TipoLogradouro);
        }

        public async Task Update(TipoLogradouro TipoLogradouro)
        {
            await this.ITipoLogradouro.Update(TipoLogradouro);
        }
    }
}
