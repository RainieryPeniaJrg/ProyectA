using BE_ProyectoA.Core.Domain.Entities.Director;
using BE_ProyectoA.Core.Domain.Entities.Votantes;
using BE_ProyectoA.Core.Domain.Entities.Votantes.VotantesDirector;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Reflection.Emit;

namespace BE_ProyectoA.Infraestructure.Persistence.Persistence.Configurations
{
    internal class VotantesDirectorConfiguration : IEntityTypeConfiguration<VotantesDirectores>
    {
        public void Configure(EntityTypeBuilder<VotantesDirectores> builder)
        {

            builder.Property(sc => sc.VotanteId)
           .HasConversion(
               cId => cId.Value,
               value => new VotanteId(value));

            builder.Property(sc => sc.DirectorId)
                .HasConversion(
                    cId => cId.Value,
                    value => new DirectoresId(value));

            builder.HasKey(vd => new { vd.VotanteId, vd.DirectorId });

            builder.HasOne(vd => vd.Votante)
                   .WithMany(v => v.VotantesDirector)
                   .HasForeignKey(vd => vd.VotanteId)
                   .OnDelete(DeleteBehavior.NoAction);

            builder.HasOne(vd => vd.Director)
                   .WithMany()
                   .HasForeignKey(vd => vd.DirectorId)
                     .OnDelete(DeleteBehavior.NoAction);




        }
    }
}
