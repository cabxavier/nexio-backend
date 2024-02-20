using Domain.Interface.IDocumento;
using Domain.Interface.Service;
using Entities.Entidade;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class DocumentoController : ControllerBase
    {
        private readonly IDocumento IDocumento;
        private readonly IDocumentoService IDocumentoService;

        public DocumentoController(IDocumento IDocumento, IDocumentoService IDocumentoService)
        {
            this.IDocumento = IDocumento;
            this.IDocumentoService = IDocumentoService;
        }

        [HttpGet("/api/documento/ListarDocumento")]
        [Produces("application/json")]
        public async Task<object> ListaDocumento()
        {
            return await this.IDocumento.ListarDocumento();
        }

        [HttpGet("/api/documento/ListarDocumentoPorIdEmpresa")]
        [Produces("application/json")]
        public async Task<object> ListarDocumentoPorIdEmpresa(int IdEmpresa)
        {
            return await this.IDocumento.ListarDocumentoPorIdEmpresa(IdEmpresa);
        }

        [HttpPost("/api/documento/Insert")]
        [Produces("application/json")]
        public async Task<object> Insert(Documento Documento)
        {
            await this.IDocumentoService.Insert(Documento);

            return Task.FromResult(Documento);
        }

        [HttpPut("/api/documento/Update")]
        [Produces("application/json")]
        public async Task<object> Update(Documento Documento)
        {
            await this.IDocumentoService.Update(Documento);

            return Task.FromResult(Documento);
        }

        [HttpDelete("/api/documento/Delete")]
        [Produces("application/json")]
        public async Task<object> Delete(int IdDocumento)
        {
            var Documento = await this.IDocumento.GetEntityById(IdDocumento);

            if (Documento != null)
            {
                await this.IDocumento.Delete(Documento);

                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
