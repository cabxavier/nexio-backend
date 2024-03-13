using Domain.Interface.ITipoLogradouro;
using Domain.Interface.Service;
using Entities.Entidade;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class TipoLogradouroController : ControllerBase
    {
        private readonly ITipoLogradouro ITipoLogradouro;
        private readonly ITipoLogradouroService ITipoLogradouroService;

        public TipoLogradouroController(ITipoLogradouro ITipoLogradouro, ITipoLogradouroService ITipoLogradouroService)
        {
            this.ITipoLogradouro = ITipoLogradouro;
            this.ITipoLogradouroService = ITipoLogradouroService;
        }

        [HttpGet("/api/TipoLogradouro/ListarTipoLogradouro")]
        [Produces("application/json")]
        public async Task<object> ListarTipoLogradouro()
        {
            return await this.ITipoLogradouro.ListarTipoLogradouro();
        }

        [HttpPost("/api/TipoLogradouro/Insert")]
        [Produces("application/json")]
        public async Task<object> Insert(TipoLogradouro TipoLogradouro)
        {
            TipoLogradouro.DataAlteracao = DateTime.Now;
            TipoLogradouro.UsuarioAlteracao = "adm";

            await this.ITipoLogradouroService.Insert(TipoLogradouro);

            return Task.FromResult(TipoLogradouro);
        }

        [HttpPut("/api/TipoLogradouro/Update")]
        [Produces("application/json")]
        public async Task<object> Update(TipoLogradouro TipoLogradouro)
        {
            TipoLogradouro.DataAlteracao = DateTime.Now;
            TipoLogradouro.UsuarioAlteracao = "adm";

            await this.ITipoLogradouroService.Update(TipoLogradouro);

            return Task.FromResult(TipoLogradouro);
        }

        [HttpDelete("/api/TipoLogradouro/Delete")]
        [Produces("application/json")]
        public async Task<object> Delete(int IdTipoLogradouro)
        {
            var TipoLogradouro = await this.ITipoLogradouro.GetEntityById(IdTipoLogradouro);

            if (TipoLogradouro != null)
            {
                await this.ITipoLogradouro.Delete(TipoLogradouro);

                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
