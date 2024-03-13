using Domain.Interface.IEstado;
using Domain.Interface.Service;
using Entities.Entidade;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class EstadoController : ControllerBase
    {
        private readonly IEstado IEstado;
        private readonly IEstadoService IEstadoService;

        public EstadoController(IEstado IEstado, IEstadoService IEstadoService)
        {
            this.IEstado = IEstado;
            this.IEstadoService = IEstadoService;
        }

        [HttpGet("/api/Estado/ListarEstado")]
        [Produces("application/json")]
        public async Task<object> ListarEstado()
        {
            return await this.IEstado.ListarEstado();
        }

        [HttpPost("/api/Estado/Insert")]
        [Produces("application/json")]
        public async Task<object> Insert(Estado Estado)
        {
            Estado.DataAlteracao = DateTime.Now;
            Estado.UsuarioAlteracao = "adm";

            await this.IEstadoService.Insert(Estado);

            return Task.FromResult(Estado);
        }

        [HttpPut("/api/Estado/Update")]
        [Produces("application/json")]
        public async Task<object> Update(Estado Estado)
        {
            Estado.DataAlteracao = DateTime.Now;
            Estado.UsuarioAlteracao = "adm";

            await this.IEstadoService.Update(Estado);

            return Task.FromResult(Estado);
        }

        [HttpDelete("/api/Estado/Delete")]
        [Produces("application/json")]
        public async Task<object> Delete(int IdEstado)
        {
            var Estado = await this.IEstado.GetEntityById(IdEstado);

            if (Estado != null)
            {
                await this.IEstado.Delete(Estado);

                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
