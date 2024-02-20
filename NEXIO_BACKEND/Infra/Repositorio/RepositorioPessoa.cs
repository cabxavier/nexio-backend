using Domain.Interface.IPessoa;
using Entities.Entidade;
using Infra.Configuracao;
using Infra.Repositorio.Generics;
using Microsoft.EntityFrameworkCore;

namespace Infra.Repositorio
{
    public class RepositorioPessoa : RepositoryGenerics<Pessoa>, IPessoa
    {
        private readonly DbContextOptions<ContextBase> DbContextOptions;

        public RepositorioPessoa()
        {
            this.DbContextOptions = new DbContextOptions<ContextBase>();
        }

        public async Task<IList<Pessoa>> ListarPessoa()
        {
            using (var banco = new ContextBase(this.DbContextOptions))
            {
                return await (from p in banco.Pessoa select p).AsNoTracking().ToListAsync();
            }
        }
    }
}
