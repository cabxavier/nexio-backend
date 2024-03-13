using Domain.Interface.IPais;
using Entities.Entidade;
using Infra.Configuracao;
using Infra.Repositorio.Generics;
using Microsoft.EntityFrameworkCore;

namespace Infra.Repositorio
{
    public class RepositorioPais : RepositoryGenerics<Pais>, IPais
    {
        private readonly DbContextOptions<ContextBase> DbContextOptions;

        public RepositorioPais()
        {
            this.DbContextOptions = new DbContextOptions<ContextBase>();
        }

        public async Task<IList<Pais>> ListarPais()
        {
            using (var banco = new ContextBase(this.DbContextOptions))
            {
                return await (from e in banco.Pais select e).AsNoTracking().ToListAsync();
            }
        }
    }
}
