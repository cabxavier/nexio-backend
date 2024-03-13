using Entities.Entidade;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Infra.Configuracao
{
    public class ContextBase : IdentityDbContext<ApplicationUser>
    {
        public ContextBase(DbContextOptions Options) : base(Options) { }

        public DbSet<Documento> Documento { get; set; }
        public DbSet<Empresa> Empresa { get; set; }
        public DbSet<Pessoa> Pessoa { get; set; }
        public DbSet<Usuario> Usuario { get; set; }
        public DbSet<Pais> Pais { get; set; }
        public DbSet<Estado> Estado { get; set; }
        public DbSet<TipoLogradouro> TipoLogradouro { get; set; }
        public DbSet<Logradouro> Logradouro { get; set; }
        public DbSet<Bairro> Bairro { get; set; }
        public DbSet<Cidade> Cidade { get; set; }
        public DbSet<Cep> Cep { get; set; }
        public DbSet<TipoEndereco> TipoEndereco { get; set; }
        public DbSet<Endereco> Endereco { get; set; }

        protected override void OnModelCreating(ModelBuilder Builder)
        {
            Builder.Entity<ApplicationUser>().ToTable("AspNetUsers").HasKey(i => i.Id);
            Builder.Entity<Documento>().ToTable("Documento").HasKey(i => i.IdDocumento);
            Builder.Entity<Empresa>().ToTable("Empresa").HasKey(i => i.IdEmpresa);
            Builder.Entity<Pessoa>().ToTable("Pessoa").HasKey(i => i.IdPessoa);
            Builder.Entity<Usuario>().ToTable("Usuario").HasKey(i => i.IdUsuario);
            Builder.Entity<Pais>().ToTable("Pais").HasKey(i => i.IdPais);
            Builder.Entity<Estado>().ToTable("Estado").HasKey(i => i.IdEstado);
            Builder.Entity<TipoLogradouro>().ToTable("TipoLogradouro").HasKey(i => i.IdTipoLogradouro);
            Builder.Entity<Logradouro>().ToTable("Logradouro").HasKey(i => i.IdLogradouro);
            Builder.Entity<Bairro>().ToTable("Bairro").HasKey(i => i.IdBairro);
            Builder.Entity<Cidade>().ToTable("Cidade").HasKey(i => i.IdCidade);
            Builder.Entity<Cep>().ToTable("Cep").HasKey(i => i.IdCep);
            Builder.Entity<TipoEndereco>().ToTable("TipoEndereco").HasKey(i => i.IdTipoEndereco);
            Builder.Entity<Endereco>().ToTable("Endereco").HasKey(i => i.IdEndereco);

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
