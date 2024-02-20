using Domain.Interface.Generics;
using Infra.Configuracao;
using Microsoft.EntityFrameworkCore;
using Microsoft.Win32.SafeHandles;
using System.Runtime.InteropServices;

namespace Infra.Repositorio.Generics
{
    public class RepositoryGenerics<T> : IGenerics<T>, IDisposable where T : class
    {
        private readonly DbContextOptions<ContextBase> DbContextOptions;

        public bool disposed = false;

        private SafeHandle handle = new SafeFileHandle(IntPtr.Zero, true);

        public RepositoryGenerics()
        {
            this.DbContextOptions = new DbContextOptions<ContextBase>();
        }

        public async Task Insert(T Objeto)
        {
            using(var data = new ContextBase(this.DbContextOptions))
            {
                await data.Set<T>().AddAsync(Objeto);
                await data.SaveChangesAsync();
            }
        }

        public async Task Delete(T Objeto)
        {
            using (var data = new ContextBase(this.DbContextOptions))
            {
                data.Set<T>().Remove(Objeto);
                await data.SaveChangesAsync();
            }
        }

        public async Task<T> GetEntityById(int Id)
        {
            using (var data = new ContextBase(this.DbContextOptions))
            {
                return await data.Set<T>().FindAsync(Id);
            }
        }

        public async Task<List<T>> List()
        {
            using (var data = new ContextBase(this.DbContextOptions))
            {
                return await data.Set<T>().ToListAsync();
            }
        }

        public async Task Update(T Objeto)
        {
            using (var data = new ContextBase(this.DbContextOptions))
            {
                 data.Set<T>().Update(Objeto);
                await data.SaveChangesAsync();
            }
        }

        public void Dispose()
        {
            this.Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (this.disposed)
                return;

            if (disposing)
            {
                this.handle.Dispose();
            }

            this.disposed = true;
        }
    }
}
