using Domain.Interface.ICidade;
using Entities.Entidade;
using Infra.Configuracao;
using Infra.Repositorio.Generics;
using Microsoft.EntityFrameworkCore;

namespace Infra.Repositorio
{
    public class RepositorioCidade : RepositoryGenerics<Cidade>, ICidade
    {
        private readonly DbContextOptions<ContextBase> DbContextOptions;

        public RepositorioCidade()
        {
            this.DbContextOptions = new DbContextOptions<ContextBase>();
        }

        public async Task<IList<Cidade>> ListarCidade()
        {
            using (var banco = new ContextBase(this.DbContextOptions))
            {
                return await (from e in banco.Cidade select e).AsNoTracking().ToListAsync();
            }
        }
    }
}
