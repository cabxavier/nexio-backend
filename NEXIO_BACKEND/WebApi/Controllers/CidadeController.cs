using Domain.Interface.ICidade;
using Domain.Interface.Service;
using Entities.Entidade;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class CidadeController : ControllerBase
    {
        private readonly ICidade ICidade;
        private readonly ICidadeService ICidadeService;

        public CidadeController(ICidade ICidade, ICidadeService ICidadeService)
        {
            this.ICidade = ICidade;
            this.ICidadeService = ICidadeService;
        }

        [HttpGet("/api/Cidade/ListarCidade")]
        [Produces("application/json")]
        public async Task<object> ListarCidade()
        {
            return await this.ICidade.ListarCidade();
        }

        [HttpPost("/api/Cidade/Insert")]
        [Produces("application/json")]
        public async Task<object> Insert(Cidade Cidade)
        {
            Cidade.DataAlteracao = DateTime.Now;
            Cidade.UsuarioAlteracao = "adm";

            await this.ICidadeService.Insert(Cidade);

            return Task.FromResult(Cidade);
        }

        [HttpPut("/api/Cidade/Update")]
        [Produces("application/json")]
        public async Task<object> Update(Cidade Cidade)
        {
            Cidade.DataAlteracao = DateTime.Now;
            Cidade.UsuarioAlteracao = "adm";

            await this.ICidadeService.Update(Cidade);

            return Task.FromResult(Cidade);
        }

        [HttpDelete("/api/Cidade/Delete")]
        [Produces("application/json")]
        public async Task<object> Delete(int IdCidade)
        {
            var Cidade = await this.ICidade.GetEntityById(IdCidade);

            if (Cidade != null)
            {
                await this.ICidade.Delete(Cidade);

                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
