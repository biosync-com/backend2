using BioSync.Infra.IoC;
using Microsoft.OpenApi.Models;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

// 1. Configura��o dos Servi�os no Container de Inje��o de Depend�ncia

// Adiciona suporte para controllers e ignora ciclos de refer�ncia no JSON
builder.Services.AddControllers()
    .AddJsonOptions(options =>
        options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);

builder.Services.AddCors(options =>
{
    options.AddPolicy("ReactPolicy", builder =>
    {
        // Permite requisi��es de qualquer origem, com qualquer cabe�alho e m�todo
        builder.WithOrigins("http://localhost:3000", "https://localhost:3000")
               .AllowAnyOrigin()
               .AllowAnyHeader()
               .AllowAnyMethod();
    });
});

// Chama nosso m�todo de extens�o para configurar toda a infraestrutura (DbContext, Identity, Repositories, Services, JWT, etc.)
builder.Services.AddInfrastructure(builder.Configuration);

// Adiciona o gerador de Endpoints da API para explora��o
builder.Services.AddEndpointsApiExplorer();

// Adiciona e configura o Swagger para documenta��o da API e suporte a JWT
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "BioSync.API", Version = "v1" });

    // Configura��o para que o Swagger UI possa enviar o token JWT nas requisi��es
    c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme()
    {
        Name = "Authorization",
        Type = SecuritySchemeType.ApiKey,
        Scheme = "Bearer",
        BearerFormat = "JWT",
        In = ParameterLocation.Header,
        Description = "Insira 'Bearer' [espa�o] e ent�o seu token no campo abaixo.\n\nExemplo: \"Bearer 12345abcdef\"",
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

// 2. Configura��o do Pipeline de Requisi��es HTTP

// Habilita o Swagger e o Swagger UI em ambiente de desenvolvimento
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// Redireciona requisi��es HTTP para HTTPS
app.UseHttpsRedirection();

// Habilita a autentica��o (essencial para validar o token JWT)
app.UseAuthentication();

// Habilita a autoriza��o (essencial para proteger os endpoints com [Authorize])
app.UseAuthorization();

// Mapeia os controllers para as rotas
app.MapControllers();

// Executa a aplica��o
app.Run();
