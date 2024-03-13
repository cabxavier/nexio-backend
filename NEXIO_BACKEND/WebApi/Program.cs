using Domain.Interface.Generics;
using Domain.Interface.IBairro;
using Domain.Interface.ICep;
using Domain.Interface.ICidade;
using Domain.Interface.IDocumento;
using Domain.Interface.IEmpresa;
using Domain.Interface.IEndereco;
using Domain.Interface.IEstado;
using Domain.Interface.ILogradouro;
using Domain.Interface.IPais;
using Domain.Interface.IPessoa;
using Domain.Interface.ITipoEndereco;
using Domain.Interface.ITipoLogradouro;
using Domain.Interface.IUsuario;
using Domain.Interface.Service;
using Domain.Servico;
using Entities.Entidade;
using Infra.Configuracao;
using Infra.Repositorio;
using Infra.Repositorio.Generics;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using WebApi.Token;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "NEXIO TECNOLOGIA API",
        Description = "Developed by Nexio Tecnologia",
        Contact = new OpenApiContact { Name = "Nexio Tecnologia", Email = "nexiotecnologia@gmail.com" },
        License = new OpenApiLicense { Name = "MIT", Url = new Uri("https://opensource.org/licenses/MIT") }
    });

    c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        Description = "Insira o token JWT desta maneira: Bearer {seu token}",
        Name = "Authorization",
        Scheme = "Bearer",
        BearerFormat = "JWT",
        In = ParameterLocation.Header,
        Type = SecuritySchemeType.Http
    });

    c.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type = ReferenceType.SecurityScheme,
                    Id = "Bearer"
                },
            },
            new string[] {}
        }
    });
});

builder.Services.AddRin();
builder.Logging.AddRinLogger();


builder.Services.AddDbContext<ContextBase>(options =>
               options.UseSqlServer(
                   builder.Configuration.GetConnectionString("DefaultConnection")));
builder.Services.AddDefaultIdentity<ApplicationUser>(options => options.SignIn.RequireConfirmedAccount = true)
    .AddEntityFrameworkStores<ContextBase>();

/***** INTERFACE E REPOSITORIO *****/
builder.Services.AddSingleton(typeof(IGenerics<>), typeof(RepositoryGenerics<>));
builder.Services.AddSingleton<IDocumento, RepositorioDocumento>();
builder.Services.AddSingleton<IEmpresa, RepositorioEmpresa>();
builder.Services.AddSingleton<IPessoa, RepositorioPessoa>();
builder.Services.AddSingleton<IUsuario, RepositorioUsuario>();
builder.Services.AddSingleton<IPais, RepositorioPais>();
builder.Services.AddSingleton<IEstado, RepositorioEstado>();
builder.Services.AddSingleton<ITipoLogradouro, RepositorioTipoLogradouro>();
builder.Services.AddSingleton<ILogradouro, RepositorioLogradouro>();
builder.Services.AddSingleton<IBairro, RepositorioBairro>();
builder.Services.AddSingleton<ICidade, RepositorioCidade>();
builder.Services.AddSingleton<ICep, RepositorioCep>();
builder.Services.AddSingleton<ITipoEndereco, RepositorioTipoEndereco>();
builder.Services.AddSingleton<IEndereco, RepositorioEndereco>();

/***** SERVIÇO E DOMINIO *****/
builder.Services.AddSingleton<IDocumentoService, DocumentoService>();
builder.Services.AddSingleton<IEmpresaService, EmpresaService>();
builder.Services.AddSingleton<IPessoaService, PessoaService>();
builder.Services.AddSingleton<IUsuarioService, UsuarioService>();
builder.Services.AddSingleton<IPaisService, PaisService>();
builder.Services.AddSingleton<IEstadoService, EstadoService>();
builder.Services.AddSingleton<ITipoLogradouroService, TipoLogradouroService>();
builder.Services.AddSingleton<ILogradouroService, LogradouroService>();
builder.Services.AddSingleton<IBairroService, BairroService>();
builder.Services.AddSingleton<ICidadeService, CidadeService>();
builder.Services.AddSingleton<ICepService, CepService>();
builder.Services.AddSingleton<ITipoEnderecoService, TipoEnderecoService>();
builder.Services.AddSingleton<IEnderecoService, EnderecoService>();

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
             .AddJwtBearer(option =>
             {
                 option.TokenValidationParameters = new TokenValidationParameters
                 {
                     ValidateIssuer = false,
                     ValidateAudience = false,
                     ValidateLifetime = true,
                     ValidateIssuerSigningKey = true,

                     ValidIssuer = "Nexio.Securiry.Bearer",
                     ValidAudience = "Nexio.Securiry.Bearer",
                     IssuerSigningKey = JwtSecurityKey.Create("S3cr3t@K3y-971$5247")
                 };

                 option.Events = new JwtBearerEvents
                 {
                     OnAuthenticationFailed = context =>
                     {
                         Console.WriteLine("OnAuthenticationFailed: " + context.Exception.Message);
                         return Task.CompletedTask;
                     },
                     OnTokenValidated = context =>
                     {
                         Console.WriteLine("OnTokenValidated: " + context.SecurityToken);
                         return Task.CompletedTask;
                     }
                 };
             });

var MyAllowSpecificOrigins = "_myAllowSpecificOrigins";

builder.Services.AddCors(options =>
{
    options.AddPolicy(MyAllowSpecificOrigins,
                          policy =>
                          {
                              policy.WithOrigins("http://localhost:4200/")
                                                  .AllowAnyOrigin()
                                                  .AllowAnyMethod()
                                                  .AllowAnyHeader();
                          });
});

builder.Services.AddControllers();


var app = builder.Build();

// Configure the HTTP request pipeline.
//if (app.Environment.IsDevelopment() || app.Environment.IsProduction())
//{

app.UseSwagger();
app.UseSwaggerUI();

app.UseRin();
app.UseRinDiagnosticsHandler();
//}

app.UseHttpsRedirection();

app.UseCors(MyAllowSpecificOrigins);

app.UseAuthentication();
app.UseAuthorization();
app.MapControllers();

app.Run();