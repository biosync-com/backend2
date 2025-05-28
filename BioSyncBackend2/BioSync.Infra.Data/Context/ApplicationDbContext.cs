using BioSync.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace BioSync.Infra.Data.Context
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options) { }

       
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Coletor> Coletores { get; set; }
        public DbSet<Agendamento> Agendamentos { get; set; }
        public DbSet<Material> Materiais { get; set; }
        public DbSet<PontoDescarte> PontosDescarte { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly);

        }
    }
}
