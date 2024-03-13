using Domain.Interface.IEndereco;
using Entities.Entidade;
using Infra.Configuracao;
using Infra.Repositorio.Generics;
using Microsoft.EntityFrameworkCore;

namespace Infra.Repositorio
{
    public class RepositorioEndereco : RepositoryGenerics<Endereco>, IEndereco
    {
        private readonly DbContextOptions<ContextBase> DbContextOptions;

        public RepositorioEndereco()
        {
            this.DbContextOptions = new DbContextOptions<ContextBase>();
        }

        public async Task<IList<Endereco>> ListarEndereco()
        {
            using (var banco = new ContextBase(this.DbContextOptions))
            {
                return await (from e in banco.Endereco select e).AsNoTracking().ToListAsync();
            }
        }
    }
}
