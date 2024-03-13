using Domain.Interface.IEndereco;
using Domain.Interface.Service;
using Entities.Entidade;

namespace Domain.Servico
{
    public class EnderecoService : IEnderecoService
    {
        private readonly IEndereco IEndereco;

        public EnderecoService(IEndereco IEndereco)
        {
            this.IEndereco = IEndereco;
        }

        public async Task Insert(Endereco Endereco)
        {
            await this.IEndereco.Insert(Endereco);
        }

        public async Task Update(Endereco Endereco)
        {
            await this.IEndereco.Update(Endereco);
        }
    }
}
