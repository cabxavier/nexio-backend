using Domain.Interface.ITipoEndereco;
using Domain.Interface.Service;
using Entities.Entidade;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class TipoEnderecoController : ControllerBase
    {
        private readonly ITipoEndereco ITipoEndereco;
        private readonly ITipoEnderecoService ITipoEnderecoService;

        public TipoEnderecoController(ITipoEndereco ITipoEndereco, ITipoEnderecoService ITipoEnderecoService)
        {
            this.ITipoEndereco = ITipoEndereco;
            this.ITipoEnderecoService = ITipoEnderecoService;
        }

        [HttpGet("/api/TipoEndereco/ListarTipoEndereco")]
        [Produces("application/json")]
        public async Task<object> ListarTipoEndereco()
        {
            return await this.ITipoEndereco.ListarTipoEndereco();
        }

        [HttpPost("/api/TipoEndereco/Insert")]
        [Produces("application/json")]
        public async Task<object> Insert(TipoEndereco TipoEndereco)
        {
            TipoEndereco.DataAlteracao = DateTime.Now;
            TipoEndereco.UsuarioAlteracao = "adm";

            await this.ITipoEnderecoService.Insert(TipoEndereco);

            return Task.FromResult(TipoEndereco);
        }

        [HttpPut("/api/TipoEndereco/Update")]
        [Produces("application/json")]
        public async Task<object> Update(TipoEndereco TipoEndereco)
        {
            TipoEndereco.DataAlteracao = DateTime.Now;
            TipoEndereco.UsuarioAlteracao = "adm";

            await this.ITipoEnderecoService.Update(TipoEndereco);

            return Task.FromResult(TipoEndereco);
        }

        [HttpDelete("/api/TipoEndereco/Delete")]
        [Produces("application/json")]
        public async Task<object> Delete(int IdTipoEndereco)
        {
            var TipoEndereco = await this.ITipoEndereco.GetEntityById(IdTipoEndereco);

            if (TipoEndereco != null)
            {
                await this.ITipoEndereco.Delete(TipoEndereco);

                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
