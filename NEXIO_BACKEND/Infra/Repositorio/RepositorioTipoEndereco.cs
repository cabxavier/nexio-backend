using Domain.Interface.ITipoEndereco;
using Entities.Entidade;
using Infra.Configuracao;
using Infra.Repositorio.Generics;
using Microsoft.EntityFrameworkCore;

namespace Infra.Repositorio
{
    public class RepositorioTipoEndereco : RepositoryGenerics<TipoEndereco>, ITipoEndereco
    {
        private readonly DbContextOptions<ContextBase> DbContextOptions;

        public RepositorioTipoEndereco()
        {
            this.DbContextOptions = new DbContextOptions<ContextBase>();
        }

        public async Task<IList<TipoEndereco>> ListarTipoEndereco()
        {
            using (var banco = new ContextBase(this.DbContextOptions))
            {
                return await (from e in banco.TipoEndereco select e).AsNoTracking().ToListAsync();
            }
        }
    }
}
