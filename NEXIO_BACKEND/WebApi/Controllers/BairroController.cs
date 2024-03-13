using Domain.Interface.IBairro;
using Domain.Interface.Service;
using Entities.Entidade;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class BairroController : ControllerBase
    {
        private readonly IBairro IBairro;
        private readonly IBairroService IBairroService;

        public BairroController(IBairro IBairro, IBairroService IBairroService)
        {
            this.IBairro = IBairro;
            this.IBairroService = IBairroService;
        }

        [HttpGet("/api/Bairro/ListarBairro")]
        [Produces("application/json")]
        public async Task<object> ListarBairro()
        {
            return await this.IBairro.ListarBairro();
        }

        [HttpPost("/api/Bairro/Insert")]
        [Produces("application/json")]
        public async Task<object> Insert(Bairro Bairro)
        {
            Bairro.DataAlteracao = DateTime.Now;
            Bairro.UsuarioAlteracao = "adm";

            await this.IBairroService.Insert(Bairro);

            return Task.FromResult(Bairro);
        }

        [HttpPut("/api/Bairro/Update")]
        [Produces("application/json")]
        public async Task<object> Update(Bairro Bairro)
        {
            Bairro.DataAlteracao = DateTime.Now;
            Bairro.UsuarioAlteracao = "adm";

            await this.IBairroService.Update(Bairro);

            return Task.FromResult(Bairro);
        }

        [HttpDelete("/api/Bairro/Delete")]
        [Produces("application/json")]
        public async Task<object> Delete(int IdBairro)
        {
            var Bairro = await this.IBairro.GetEntityById(IdBairro);

            if (Bairro != null)
            {
                await this.IBairro.Delete(Bairro);

                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
