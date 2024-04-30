using BE_ProyectoA.Core.Domain.Entities.CoordinadorGeneral;
using BE_ProyectoA.Core.Domain.Entities.Votantes;
using BE_ProyectoA.Core.Domain.Entities.Votantes.VotantesCoordinadorGeneral;
using BE_ProyectoA.Core.Domain.Entities.Votantes.VotantesDirector;
using BE_ProyectoA.Core.Domain.Entities.Votantes.VotantesSubCoordinadores;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BE_ProyectoA.Infraestructure.Persistence.Persistence.Configurations
{
    internal class VotanteCoordinadorConfiguration : IEntityTypeConfiguration<VotantesCoordinadoresGenerales>
    {
        public void Configure(EntityTypeBuilder<VotantesCoordinadoresGenerales> builder)
        {
            builder.Property(sc => sc.VotanteId)
           .HasConversion(
               cId => cId.Value,
               value => new VotanteId(value));

            builder.Property(sc => sc.CoordinadorId)
                .HasConversion(
                    cId => cId.Value,
                    value => new CoordinadoresGeneralesId(value));

            builder.HasKey(vc => new { vc.VotanteId, vc.CoordinadorId });


            builder.HasOne(vc => vc.Votante)
                   .WithMany(v => v.VotantesCoordinadoresGenerales)
                   .HasForeignKey(vc => vc.VotanteId)
                   .OnDelete(DeleteBehavior.NoAction);

            builder.HasOne(vc => vc.Coordinador)
                   .WithMany()
                   .HasForeignKey(vc => vc.CoordinadorId)
                     .OnDelete(DeleteBehavior.NoAction);





        }
    }
}
