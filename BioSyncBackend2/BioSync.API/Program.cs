using BioSync.Infra.IoC;
using Microsoft.OpenApi.Models;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

// 1. Configuração dos Serviços no Container de Injeção de Dependência

// Adiciona suporte para controllers e ignora ciclos de referência no JSON
builder.Services.AddControllers()
    .AddJsonOptions(options =>
        options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);

builder.Services.AddCors(options =>
{
    options.AddPolicy("ReactPolicy", builder =>
    {
        // Permite requisições de qualquer origem, com qualquer cabeçalho e método
        builder.WithOrigins("http://localhost:3000", "https://localhost:3000")
               .AllowAnyOrigin()
               .AllowAnyHeader()
               .AllowAnyMethod();
    });
});

// Chama nosso método de extensão para configurar toda a infraestrutura (DbContext, Identity, Repositories, Services, JWT, etc.)
builder.Services.AddInfrastructure(builder.Configuration);

// Adiciona o gerador de Endpoints da API para exploração
builder.Services.AddEndpointsApiExplorer();

// Adiciona e configura o Swagger para documentação da API e suporte a JWT
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "BioSync.API", Version = "v1" });

    // Configuração para que o Swagger UI possa enviar o token JWT nas requisições
    c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme()
    {
        Name = "Authorization",
        Type = SecuritySchemeType.ApiKey,
        Scheme = "Bearer",
        BearerFormat = "JWT",
        In = ParameterLocation.Header,
        Description = "Insira 'Bearer' [espaço] e então seu token no campo abaixo.\n\nExemplo: \"Bearer 12345abcdef\"",
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
                }
            },
            new string[] {}
        }
    });
});


var app = builder.Build();

app.UseCors("ReactPolicy");

// 2. Configuração do Pipeline de Requisições HTTP

// Habilita o Swagger e o Swagger UI em ambiente de desenvolvimento
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// Redireciona requisições HTTP para HTTPS
app.UseHttpsRedirection();

// Habilita a autenticação (essencial para validar o token JWT)
app.UseAuthentication();

// Habilita a autorização (essencial para proteger os endpoints com [Authorize])
app.UseAuthorization();

// Mapeia os controllers para as rotas
app.MapControllers();

// Executa a aplicação
app.Run();
