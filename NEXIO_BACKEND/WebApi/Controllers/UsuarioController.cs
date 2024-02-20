using Domain.Interface.IUsuario;
using Domain.Interface.Service;
using Entities.Entidade;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class UsuarioController : ControllerBase
    {
        private readonly IUsuario IUsuario;
        private readonly IUsuarioService IUsuarioService;

        public UsuarioController(IUsuario IUsuario, IUsuarioService IUsuarioService)
        {
            this.IUsuario = IUsuario;
            this.IUsuarioService = IUsuarioService;
        }

        [HttpGet("/api/usuario/ListarUsuario")]
        [Produces("application/json")]
        public async Task<object> ListarUsuario()
        {
            return await this.IUsuario.ListarUsuario();
        }

        [HttpPost("/api/usuario/Insert")]
        [Produces("application/json")]
        public async Task<object> Insert(Usuario Usuario)
        {
            await this.IUsuarioService.Insert(Usuario);

            return Task.FromResult(Usuario);
        }

        [HttpPut("/api/usuario/Update")]
        [Produces("application/json")]
        public async Task<object> Update(Usuario Usuario)
        {
            await this.IUsuarioService.Update(Usuario);

            return Task.FromResult(Usuario);
        }

        [HttpDelete("/api/usuario/Delete")]
        [Produces("application/json")]
        public async Task<object> Delete(int IdUsuario)
        {
            var Usuario = await this.IUsuario.GetEntityById(IdUsuario);

            if (Usuario != null)
            {
                await this.IUsuario.Delete(Usuario);

                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
