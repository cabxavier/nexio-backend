using Domain.Interface.IEmpresa;
using Entities.Entidade;
using Infra.Configuracao;
using Infra.Repositorio.Generics;
using Microsoft.EntityFrameworkCore;

namespace Infra.Repositorio
{
    public class RepositorioEmpresa : RepositoryGenerics<Empresa>, IEmpresa
    {
        private readonly DbContextOptions<ContextBase> DbContextOptions;

        public RepositorioEmpresa()
        {
            this.DbContextOptions = new DbContextOptions<ContextBase>();
        }

        public async Task<IList<Empresa>> ListarEmpresa()
        {
            using (var banco = new ContextBase(this.DbContextOptions))
            {
                return await (from e in banco.Empresa select e).AsNoTracking().ToListAsync();
            }
        }
    }
}
