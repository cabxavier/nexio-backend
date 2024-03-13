using Domain.Interface.IEstado;
using Entities.Entidade;
using Infra.Configuracao;
using Infra.Repositorio.Generics;
using Microsoft.EntityFrameworkCore;

namespace Infra.Repositorio
{
    public class RepositorioEstado : RepositoryGenerics<Estado>, IEstado
    {
        private readonly DbContextOptions<ContextBase> DbContextOptions;

        public RepositorioEstado()
        {
            this.DbContextOptions = new DbContextOptions<ContextBase>();
        }

        public async Task<IList<Estado>> ListarEstado()
        {
            using (var banco = new ContextBase(this.DbContextOptions))
            {
                return await (from e in banco.Estado select e).AsNoTracking().ToListAsync();
            }
        }
    }
}
