using Domain.Interface.ILogradouro;
using Entities.Entidade;
using Infra.Configuracao;
using Infra.Repositorio.Generics;
using Microsoft.EntityFrameworkCore;

namespace Infra.Repositorio
{
    public class RepositorioLogradouro : RepositoryGenerics<Logradouro>, ILogradouro
    {
        private readonly DbContextOptions<ContextBase> DbContextOptions;

        public RepositorioLogradouro()
        {
            this.DbContextOptions = new DbContextOptions<ContextBase>();
        }

        public async Task<IList<Logradouro>> ListarLogradouro()
        {
            using (var banco = new ContextBase(this.DbContextOptions))
            {
                return await (from e in banco.Logradouro select e).AsNoTracking().ToListAsync();
            }
        }
    }
}
