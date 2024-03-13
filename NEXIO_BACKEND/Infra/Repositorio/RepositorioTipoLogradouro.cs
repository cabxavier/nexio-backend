using Domain.Interface.ITipoLogradouro;
using Entities.Entidade;
using Infra.Configuracao;
using Infra.Repositorio.Generics;
using Microsoft.EntityFrameworkCore;

namespace Infra.Repositorio
{
    public class RepositorioTipoLogradouro : RepositoryGenerics<TipoLogradouro>, ITipoLogradouro
    {
        private readonly DbContextOptions<ContextBase> DbContextOptions;

        public RepositorioTipoLogradouro()
        {
            this.DbContextOptions = new DbContextOptions<ContextBase>();
        }

        public async Task<IList<TipoLogradouro>> ListarTipoLogradouro()
        {
            using (var banco = new ContextBase(this.DbContextOptions))
            {
                return await (from e in banco.TipoLogradouro select e).AsNoTracking().ToListAsync();
            }
        }
    }
}
