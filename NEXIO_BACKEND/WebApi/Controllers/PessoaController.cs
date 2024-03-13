using Domain.Interface.IPessoa;
using Domain.Interface.Service;
using Entities.Entidade;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class PessoaController : ControllerBase
    {
        private readonly IPessoa IPessoa;
        private readonly IPessoaService IPessoaService;

        public PessoaController(IPessoa IPessoa, IPessoaService IPessoaService)
        {
            this.IPessoa = IPessoa;
            this.IPessoaService = IPessoaService;
        }

        [HttpGet("/api/pessoa/ListarPessoa")]
        [Produces("application/json")]
        public async Task<object> ListarPessoa()
        {
            return await this.IPessoa.ListarPessoa();
        }

        [HttpPost("/api/pessoa/Insert")]
        [Produces("application/json")]
        public async Task<object> Insert(Pessoa Pessoa)
        {
            Pessoa.DataAlteracao = DateTime.Now;
            Pessoa.UsuarioAlteracao = "adm";

            if (Pessoa.IdUsuario == 0)
            {
                Pessoa.IdUsuario = null;
            }

            if (string.IsNullOrWhiteSpace(Pessoa.CodigoInterno))
            {
                Pessoa.CodigoInterno = null;
            }

            if (string.IsNullOrEmpty(Pessoa.Cnpj))
            {
                Pessoa.Cnpj = null;
            }

            if (string.IsNullOrEmpty(Pessoa.Cpf))
            {
                Pessoa.Cpf = null;
            }

            if (string.IsNullOrEmpty(Pessoa.EmailPrincipal))
            {
                Pessoa.EmailPrincipal = null;
            }

            if (string.IsNullOrEmpty(Pessoa.EmailSecundario))
            {
                Pessoa.EmailSecundario = null;
            }

            await this.IPessoaService.Insert(Pessoa);

            return Task.FromResult(Pessoa);
        }

        [HttpPut("/api/pessoa/Update")]
        [Produces("application/json")]
        public async Task<object> Update(Pessoa Pessoa)
        {
            Pessoa.DataAlteracao = DateTime.Now;
            Pessoa.UsuarioAlteracao = "adm";

            if (Pessoa.IdUsuario == 0)
            {
                Pessoa.IdUsuario = null;
            }

            if (string.IsNullOrWhiteSpace(Pessoa.CodigoInterno))
            {
                Pessoa.CodigoInterno = null;
            }

            if (string.IsNullOrEmpty(Pessoa.Cnpj))
            {
                Pessoa.Cnpj = null;
            }

            if (string.IsNullOrEmpty(Pessoa.Cpf))
            {
                Pessoa.Cpf = null;
            }

            if (string.IsNullOrEmpty(Pessoa.EmailPrincipal))
            {
                Pessoa.EmailPrincipal = null;
            }

            if (string.IsNullOrEmpty(Pessoa.EmailSecundario))
            {
                Pessoa.EmailSecundario = null;
            }

            await this.IPessoaService.Update(Pessoa);

            return Task.FromResult(Pessoa);
        }

        [HttpDelete("/api/pessoa/Delete")]
        [Produces("application/json")]
        public async Task<object> Delete(int IdPessoa)
        {
            var Pessoa = await this.IPessoa.GetEntityById(IdPessoa);

            if (Pessoa != null)
            {
                await this.IPessoa.Delete(Pessoa);

                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
