using BE_ProyectoA.Core.Domain.Entities.DirigenteMultiplicador;
using BE_ProyectoA.Core.Domain.Entities.Votantes;
using BE_ProyectoA.Core.Domain.Entities.Votantes.VotantesDirigentesEntity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BE_ProyectoA.Infraestructure.Persistence.Persistence.Configurations
{
    internal class VotantesDirigenteConfiguration : IEntityTypeConfiguration<VotantesDirigentes>
    {
        public void Configure(EntityTypeBuilder<VotantesDirigentes> builder)
        {

            builder.Property(sc => sc.VotanteId)
           .HasConversion(
               cId => cId.Value,
               value => new VotanteId(value));

            builder.Property(sc => sc.DirigenteId)
                .HasConversion(
                    cId => cId.Value,
                    value => new DirigentesMultiplicadoresId(value));

            builder.HasKey(vd => new { vd.VotanteId, vd.DirigenteId });

            builder.HasOne(vd => vd.Votante)
                   .WithMany(v => v.VotantesDirigentes)
                   .HasForeignKey(vd => vd.VotanteId)
                   .OnDelete(DeleteBehavior.NoAction);

            builder.HasOne(vd => vd.Dirigente)
                   .WithMany()
                   .HasForeignKey(vd => vd.DirigenteId)
                     .OnDelete(DeleteBehavior.NoAction);




        }
    }
}
