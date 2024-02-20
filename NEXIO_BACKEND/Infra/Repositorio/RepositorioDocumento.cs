using Domain.Interface.IDocumento;
using Entities.Entidade;
using Infra.Configuracao;
using Infra.Repositorio.Generics;
using Microsoft.EntityFrameworkCore;

namespace Infra.Repositorio
{
    public class RepositorioDocumento : RepositoryGenerics<Documento>, IDocumento
    {
        private readonly DbContextOptions<ContextBase> DbContextOptions;

        public RepositorioDocumento()
        {
            this.DbContextOptions = new DbContextOptions<ContextBase>();
        }

        public async Task<IList<Documento>> ListarDocumento()
        {
            using (var banco = new ContextBase(this.DbContextOptions))
            {
                return await (from d in banco.Documento select d).AsNoTracking().ToListAsync();
            }
        }
        
        public async Task<IList<Documento>> ListarDocumentoPorIdEmpresa(int IdEmpresa)
        {
            using (var banco = new ContextBase(this.DbContextOptions))
            {
                return await banco.Documento.Where(d => d.IdEmpresa == IdEmpresa).AsNoTracking().ToListAsync();
            }
        }
    }
}
