using Domain.Interface.IEmpresa;
using Domain.Interface.Service;
using Entities.Entidade;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class EmpresaController : ControllerBase
    {
        private readonly IEmpresa IEmpresa;
        private readonly IEmpresaService IEmpresaService;

        public EmpresaController(IEmpresa IEmpresa, IEmpresaService IEmpresaService)
        {
            this.IEmpresa = IEmpresa;
            this.IEmpresaService = IEmpresaService;
        }

        [HttpGet("/api/empresa/ListarEmpresa")]
        [Produces("application/json")]
        public async Task<object> ListarEmpresa()
        {
            return await this.IEmpresa.ListarEmpresa();
        }

        [HttpPost("/api/empresa/Insert")]
        [Produces("application/json")]
        public async Task<object> Insert(Empresa Empresa)
        {
            await this.IEmpresaService.Insert(Empresa);

            return Task.FromResult(Empresa);
        }

        [HttpPut("/api/empresa/Update")]
        [Produces("application/json")]
        public async Task<object> Update(Empresa Empresa)
        {
            await this.IEmpresaService.Update(Empresa);

            return Task.FromResult(Empresa);
        }

        [HttpDelete("/api/empresa/Delete")]
        [Produces("application/json")]
        public async Task<object> Delete(int IdEmpresa)
        {
            var Empresa = await this.IEmpresa.GetEntityById(IdEmpresa);

            if (Empresa != null)
            {
                await this.IEmpresa.Delete(Empresa);

                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
