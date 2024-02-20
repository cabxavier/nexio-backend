using Entities.Entidade;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Infra.Configuracao
{
    public class ContextBase : IdentityDbContext<ApplicationUser>
    {
        public ContextBase(DbContextOptions Options) : base(Options)
        {

        }

        public DbSet<Documento> Documento { get; set; }
        public DbSet<Empresa> Empresa { get; set; }
        public DbSet<Pessoa> Pessoa { get; set; }
        public DbSet<Usuario> Usuario { get; set; }

        protected override void OnModelCreating(ModelBuilder Builder)
        {
            Builder.Entity<ApplicationUser>().ToTable("AspNetUsers").HasKey(i => i.Id);
            Builder.Entity<Documento>().ToTable("Documento").HasKey(i => i.IdDocumento);
            Builder.Entity<Empresa>().ToTable("Empresa").HasKey(i => i.IdEmpresa);
            Builder.Entity<Pessoa>().ToTable("Pessoa").HasKey(i => i.IdPessoa);
            Builder.Entity<Usuario>().ToTable("Usuario").HasKey(i => i.IdUsuario);

            base.OnModelCreating(Builder);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder OptionsBuilder)
        {
            if (!OptionsBuilder.IsConfigured)
            {
                OptionsBuilder.UseSqlServer(this.ObterStringConexao());
                base.OnConfiguring(OptionsBuilder);
            }
        }

        public string ObterStringConexao()
        {

            IConfigurationRoot Configuration = new ConfigurationBuilder()
                .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
                .AddJsonFile("appsettings.json")
                .Build();

            return Configuration.GetConnectionString("DefaultConnection");

            //return "Data Source=NOTEMICROSERV;Pooling=TRUE;Connection Lifetime=30;Max Pool Size=50;Application Name=Nexios;Initial Catalog=Nexios;User ID=sa;Password=sql@2017";

        }
    }
}
