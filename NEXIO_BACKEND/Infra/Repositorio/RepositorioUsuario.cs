using Domain.Interface.IUsuario;
using Entities.Entidade;
using Infra.Configuracao;
using Infra.Repositorio.Generics;
using Microsoft.EntityFrameworkCore;

namespace Infra.Repositorio
{
    public class RepositorioUsuario : RepositoryGenerics<Usuario>, IUsuario
    {
        private readonly DbContextOptions<ContextBase> DbContextOptions;

        public RepositorioUsuario()
        {
            this.DbContextOptions = new DbContextOptions<ContextBase>();
        }

        public async Task<IList<Usuario>> ListarUsuario()
        {
            using (var banco = new ContextBase(this.DbContextOptions))
            {
                return await (from u in banco.Usuario select u).AsNoTracking().ToListAsync();
            }
        }
    }
}
