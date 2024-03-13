using Domain.Interface.ICep;
using Entities.Entidade;
using Infra.Configuracao;
using Infra.Repositorio.Generics;
using Microsoft.EntityFrameworkCore;

namespace Infra.Repositorio
{
    public class RepositorioCep : RepositoryGenerics<Cep>, ICep
    {
        private readonly DbContextOptions<ContextBase> DbContextOptions;

        public RepositorioCep()
        {
            this.DbContextOptions = new DbContextOptions<ContextBase>();
        }

        public async Task<IList<Cep>> ListarCep()
        {
            using (var banco = new ContextBase(this.DbContextOptions))
            {
                return await (from e in banco.Cep select e).AsNoTracking().ToListAsync();
            }
        }
    }
}
