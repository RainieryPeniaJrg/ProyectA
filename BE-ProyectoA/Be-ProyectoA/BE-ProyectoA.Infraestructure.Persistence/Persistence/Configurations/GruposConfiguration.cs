using BE_ProyectoA.Core.Domain.Entities.GruposEntity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BE_ProyectoA.Infraestructure.Persistence.Persistence.Configurations
{
    internal class GruposConfiguration : IEntityTypeConfiguration<Grupos>
    {
        public void Configure(EntityTypeBuilder<Grupos> builder)
        {
            builder.HasKey(g => g.Id);

            builder.Property(g => g.Id).HasConversion
                (
                grupoId => grupoId.Value,
                value => new GruposId(value)
                );

            builder.HasOne(g => g.CoordinadoresGenerales)
                .WithMany(cg => cg.Grupos)
                .HasForeignKey(g => g.CoordinadoresGeneralesId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(g => g.DirigentesMultiplicadores)
               .WithMany(cg => cg.Grupos)
               .HasForeignKey(g => g.DirigentesMultiplicadoresId)
               .OnDelete(DeleteBehavior.Restrict);


            builder.HasOne(g => g.SubCoordinadores)
               .WithMany(cg => cg.Grupos)
               .HasForeignKey(g => g.SubCoordinadoresId)
               .OnDelete(DeleteBehavior.Restrict);

            builder.Property(g => g.NombreGrupo);

            builder.Property(g => g.Active);
        }
    }
}
