using Domain.Interface.ILogradouro;
using Domain.Interface.Service;
using Entities.Entidade;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class LogradouroController : ControllerBase
    {
        private readonly ILogradouro ILogradouro;
        private readonly ILogradouroService ILogradouroService;

        public LogradouroController(ILogradouro ILogradouro, ILogradouroService ILogradouroService)
        {
            this.ILogradouro = ILogradouro;
            this.ILogradouroService = ILogradouroService;
        }

        [HttpGet("/api/Logradouro/ListarLogradouro")]
        [Produces("application/json")]
        public async Task<object> ListarLogradouro()
        {
            return await this.ILogradouro.ListarLogradouro();
        }

        [HttpPost("/api/Logradouro/Insert")]
        [Produces("application/json")]
        public async Task<object> Insert(Logradouro Logradouro)
        {
            Logradouro.DataAlteracao = DateTime.Now;
            Logradouro.UsuarioAlteracao = "adm";

            await this.ILogradouroService.Insert(Logradouro);

            return Task.FromResult(Logradouro);
        }

        [HttpPut("/api/Logradouro/Update")]
        [Produces("application/json")]
        public async Task<object> Update(Logradouro Logradouro)
        {
            Logradouro.DataAlteracao = DateTime.Now;
            Logradouro.UsuarioAlteracao = "adm";

            await this.ILogradouroService.Update(Logradouro);

            return Task.FromResult(Logradouro);
        }

        [HttpDelete("/api/Logradouro/Delete")]
        [Produces("application/json")]
        public async Task<object> Delete(int IdLogradouro)
        {
            var Logradouro = await this.ILogradouro.GetEntityById(IdLogradouro);

            if (Logradouro != null)
            {
                await this.ILogradouro.Delete(Logradouro);

                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
