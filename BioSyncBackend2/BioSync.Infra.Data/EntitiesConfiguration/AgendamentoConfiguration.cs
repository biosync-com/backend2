using BioSync.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BioSync.Infra.Data.EntitiesConfiguration
{
    public class AgendamentoConfiguration : IEntityTypeConfiguration<Agendamento>
    {
        public void Configure(EntityTypeBuilder<Agendamento> builder)
        {
            builder.HasKey(t => t.Id);

            builder.Property(p => p.Data).IsRequired();
            builder.Property(p => p.Hora).IsRequired();
            

            builder.HasOne(e => e.Usuario)
                .WithMany()
                .HasForeignKey(e => e.Id)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(e => e.Coletor)
                .WithMany()
                .HasForeignKey(e => e.Id)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(e => e.Material)
                .WithMany()
                .OnDelete(DeleteBehavior.Restrict);

        }
    }
}
