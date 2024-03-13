using Domain.Interface.IEndereco;
using Domain.Interface.Service;
using Entities.Entidade;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class EnderecoController : ControllerBase
    {
        private readonly IEndereco IEndereco;
        private readonly IEnderecoService IEnderecoService;

        public EnderecoController(IEndereco IEndereco, IEnderecoService IEnderecoService)
        {
            this.IEndereco = IEndereco;
            this.IEnderecoService = IEnderecoService;
        }

        [HttpGet("/api/Endereco/ListarEndereco")]
        [Produces("application/json")]
        public async Task<object> ListarEndereco()
        {
            return await this.IEndereco.ListarEndereco();
        }

        [HttpPost("/api/Endereco/Insert")]
        [Produces("application/json")]
        public async Task<object> Insert(Endereco Endereco)
        {
            Endereco.DataAlteracao = DateTime.Now;
            Endereco.UsuarioAlteracao = "adm";

            if (string.IsNullOrWhiteSpace(Endereco.Telefone))
            {
                Endereco.Telefone = null;
            }

            if (string.IsNullOrWhiteSpace(Endereco.Celular))
            {
                Endereco.Celular = null;
            }

            if (string.IsNullOrWhiteSpace(Endereco.Complemento))
            {
                Endereco.Complemento = null;
            }

            if (string.IsNullOrWhiteSpace(Endereco.Observacao))
            {
                Endereco.Observacao = null;
            }

            await this.IEnderecoService.Insert(Endereco);

            return Task.FromResult(Endereco);
        }

        [HttpPut("/api/Endereco/Update")]
        [Produces("application/json")]
        public async Task<object> Update(Endereco Endereco)
        {
            Endereco.DataAlteracao = DateTime.Now;
            Endereco.UsuarioAlteracao = "adm";

            if (string.IsNullOrWhiteSpace(Endereco.Telefone))
            {
                Endereco.Telefone = null;
            }

            if (string.IsNullOrWhiteSpace(Endereco.Celular))
            {
                Endereco.Celular = null;
            }

            if (string.IsNullOrWhiteSpace(Endereco.Complemento))
            {
                Endereco.Complemento = null;
            }

            if (string.IsNullOrWhiteSpace(Endereco.Observacao))
            {
                Endereco.Observacao = null;
            }

            await this.IEnderecoService.Update(Endereco);

            return Task.FromResult(Endereco);
        }

        [HttpDelete("/api/Endereco/Delete")]
        [Produces("application/json")]
        public async Task<object> Delete(int IdEndereco)
        {
            var Endereco = await this.IEndereco.GetEntityById(IdEndereco);

            if (Endereco != null)
            {
                await this.IEndereco.Delete(Endereco);

                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
