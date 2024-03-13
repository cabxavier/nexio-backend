using Domain.Interface.IBairro;
using Entities.Entidade;
using Infra.Configuracao;
using Infra.Repositorio.Generics;
using Microsoft.EntityFrameworkCore;

namespace Infra.Repositorio
{
    public class RepositorioBairro : RepositoryGenerics<Bairro>, IBairro
    {
        private readonly DbContextOptions<ContextBase> DbContextOptions;

        public RepositorioBairro()
        {
            this.DbContextOptions = new DbContextOptions<ContextBase>();
        }

        public async Task<IList<Bairro>> ListarBairro()
        {
            using (var banco = new ContextBase(this.DbContextOptions))
            {
                return await (from e in banco.Bairro select e).AsNoTracking().ToListAsync();
            }
        }
    }
}
