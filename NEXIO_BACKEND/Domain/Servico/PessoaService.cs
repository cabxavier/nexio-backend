using Domain.Interface.IPessoa;
using Domain.Interface.Service;
using Entities.Entidade;

namespace Domain.Servico
{
    // aqui entra a validação da classe notificar
    public class PessoaService : IPessoaService
    {
        private readonly IPessoa IPessoa;

        public PessoaService(IPessoa IPessoa)
        {
            this.IPessoa = IPessoa;
        }

        public async Task Insert(Pessoa Pessoa)
        {
            await this.IPessoa.Insert(Pessoa);
        }

        public async Task Update(Pessoa Pessoa)
        {
            await this.IPessoa.Update(Pessoa);
        }
    }
}
