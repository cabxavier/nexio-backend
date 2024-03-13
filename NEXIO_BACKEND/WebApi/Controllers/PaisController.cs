using Domain.Interface.IPais;
using Domain.Interface.Service;
using Entities.Entidade;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class PaisController : ControllerBase
    {
        private readonly IPais IPais;
        private readonly IPaisService IPaisService;

        public PaisController(IPais IPais, IPaisService IPaisService)
        {
            this.IPais = IPais;
            this.IPaisService = IPaisService;
        }

        [HttpGet("/api/Pais/ListarPais")]
        [Produces("application/json")]
        public async Task<object> ListarPais()
        {
            return await this.IPais.ListarPais();
        }

        [HttpPost("/api/Pais/Insert")]
        [Produces("application/json")]
        public async Task<object> Insert(Pais Pais)
        {
            Pais.DataAlteracao = DateTime.Now;
            Pais.UsuarioAlteracao = "adm";

            await this.IPaisService.Insert(Pais);

            return Task.FromResult(Pais);
        }

        [HttpPut("/api/Pais/Update")]
        [Produces("application/json")]
        public async Task<object> Update(Pais Pais)
        {
            Pais.DataAlteracao = DateTime.Now;
            Pais.UsuarioAlteracao = "adm";

            await this.IPaisService.Update(Pais);

            return Task.FromResult(Pais);
        }

        [HttpDelete("/api/Pais/Delete")]
        [Produces("application/json")]
        public async Task<object> Delete(int IdPais)
        {
            var Pais = await this.IPais.GetEntityById(IdPais);

            if (Pais != null)
            {
                await this.IPais.Delete(Pais);

                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
