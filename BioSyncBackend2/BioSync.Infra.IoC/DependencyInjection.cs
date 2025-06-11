using BioSync.Application.Interfaces;
using BioSync.Application.Mappings;
using BioSync.Application.Services;
using BioSync.Domain.Account;
using BioSync.Domain.Interfaces;
using BioSync.Infra.Data.Context;
using BioSync.Infra.Data.Identity;
using BioSync.Infra.Data.Repositories;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace BioSync.Infra.IoC
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            // 1. Configuração do DbContext
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"),
                b => b.MigrationsAssembly(typeof(ApplicationDbContext).Assembly.FullName)));

            // 2. Configuração do ASP.NET Core Identity
            services.AddIdentity<ApplicationUser, IdentityRole>()
                .AddEntityFrameworkStores<ApplicationDbContext>()
                .AddDefaultTokenProviders();

            // 3. Configuração da Autenticação com JWT
            services.AddAuthentication(opt =>
            {
                opt.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                opt.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(options =>
            {
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    ValidIssuer = configuration["Jwt:Issuer"],
                    ValidAudience = configuration["Jwt:Audience"],
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["Jwt:Key"]))
                };
            });

            // 4. Registro dos Repositórios
            services.AddScoped<IUsuarioRepository, UsuarioRepository>();
            services.AddScoped<IMaterialRepository, MaterialRepository>();
            services.AddScoped<IColetorRepository, ColetorRepository>();
            services.AddScoped<IPontoDescarteRepository, PontoDescarteRepository>();
            services.AddScoped<IAgendamentoRepository, AgendamentoRepository>();

            // 5. Registro dos Serviços de Aplicação e Autenticação
            services.AddScoped<IAuthenticate, AuthenticateService>();
            services.AddScoped<ITokenService, TokenService>();
            
            services.AddScoped<IUsuarioService, UsuarioService>();
            services.AddScoped<IMaterialService, MaterialService>();
            services.AddScoped<IColetorService, ColetorService>();
            services.AddScoped<IPontoDescarteService, PontoDescarteService>();
            services.AddScoped<IAgendamentoService, AgendamentoService>();

            // 6. Registro do AutoMapper
            services.AddAutoMapper(typeof(DomainToDTOMappingProfile));

            return services;
        }
    }
}