using Domain.Interface.ICep;
using Domain.Interface.Service;
using Entities.Entidade;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class CepController : ControllerBase
    {
        private readonly ICep ICep;
        private readonly ICepService ICepService;

        public CepController(ICep ICep, ICepService ICepService)
        {
            this.ICep = ICep;
            this.ICepService = ICepService;
        }

        [HttpGet("/api/Cep/ListarCep")]
        [Produces("application/json")]
        public async Task<object> ListarCep()
        {
            return await this.ICep.ListarCep();
        }

        [HttpPost("/api/Cep/Insert")]
        [Produces("application/json")]
        public async Task<object> Insert(Cep Cep)
        {
            Cep.DataAlteracao = DateTime.Now;
            Cep.UsuarioAlteracao = "adm";

            if (string.IsNullOrWhiteSpace(Cep.Complemento))
            {
                Cep.Complemento = null;
            }

            await this.ICepService.Insert(Cep);

            return Task.FromResult(Cep);
        }

        [HttpPut("/api/Cep/Update")]
        [Produces("application/json")]
        public async Task<object> Update(Cep Cep)
        {
            Cep.DataAlteracao = DateTime.Now;
            Cep.UsuarioAlteracao = "adm";

            if (string.IsNullOrWhiteSpace(Cep.Complemento))
            {
                Cep.Complemento = null;
            }

            await this.ICepService.Update(Cep);

            return Task.FromResult(Cep);
        }

        [HttpDelete("/api/Cep/Delete")]
        [Produces("application/json")]
        public async Task<object> Delete(int IdCep)
        {
            var Cep = await this.ICep.GetEntityById(IdCep);

            if (Cep != null)
            {
                await this.ICep.Delete(Cep);

                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
