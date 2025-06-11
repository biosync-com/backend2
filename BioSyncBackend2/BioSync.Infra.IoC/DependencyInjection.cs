using System.Text;
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

namespace BioSync.Infra.IoC
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            // 1. REGISTRO DO DBCONTEXT
            var connectionString = configuration.GetConnectionString("DefaultConnection");
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(connectionString));

            //// 2. REGISTRO DO IDENTITY (ISSO CORRIGE O ERRO DO 'UserManager')
            services.AddIdentity<ApplicationUser, IdentityRole>()
                .AddEntityFrameworkStores<ApplicationDbContext>()
                .AddDefaultTokenProviders();

            // 3. REGISTRO DOS REPOSITÓRIOS (CORRIGE OS ERROS DE 'Unable to resolve service')
            services.AddScoped<IUsuarioRepository, UsuarioRepository>();
            services.AddScoped<IMaterialRepository, MaterialRepository>();
            services.AddScoped<IColetorRepository, ColetorRepository>();
            services.AddScoped<IPontoDescarteRepository, PontoDescarteRepository>();
            services.AddScoped<IAgendamentoRepository, AgendamentoRepository>();

            // 4. REGISTRO DOS SERVIÇOS DA CAMADA DE APLICAÇÃO
            services.AddScoped<IAuthenticate, AuthenticateService>();
            services.AddScoped<ITokenService, TokenService>(); // Serviço de autenticação
            services.AddScoped<IUsuarioService, UsuarioService>();
            services.AddScoped<IMaterialService, MaterialService>();
            services.AddScoped<IColetorService, ColetorService>();
            services.AddScoped<IPontoDescarteService, PontoDescarteService>();
            services.AddScoped<IAgendamentoService, AgendamentoService>();

            // 5. REGISTRO DO AUTOMAPPER
            services.AddAutoMapper(typeof(DomainToDTOMappingProfile));

            // 6. CONFIGURAÇÃO DA AUTENTICAÇÃO JWT
            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
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
                    IssuerSigningKey = new SymmetricSecurityKey(
                        Encoding.UTF8.GetBytes(configuration["Jwt:SecretKey"]))
                };
            });

            return services;
        }
    }
}