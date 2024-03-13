using Domain.Interface.ILogradouro;
using Domain.Interface.Service;
using Entities.Entidade;

namespace Domain.Servico
{
    public class LogradouroService : ILogradouroService
    {
        private readonly ILogradouro ILogradouro;

        public LogradouroService(ILogradouro ILogradouro)
        {
            this.ILogradouro = ILogradouro;
        }

        public async Task Insert(Logradouro Logradouro)
        {
            await this.ILogradouro.Insert(Logradouro);
        }

        public async Task Update(Logradouro Logradouro)
        {
            await this.ILogradouro.Update(Logradouro);
        }
    }
}
