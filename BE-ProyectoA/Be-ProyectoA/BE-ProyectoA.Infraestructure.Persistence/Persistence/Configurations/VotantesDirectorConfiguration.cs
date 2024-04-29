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
            builder.HasKey(gs => new { gs.VotanteId, gs.DirectoresId });

            builder
            .HasOne(vd => vd.Votante)
            .WithOne(v => v.VotantesDirector)
            .HasForeignKey<VotantesDirectores>(vd => vd.VotanteId);

            builder
                .HasOne(vd => vd.Directores)
                .WithOne(d => d.VotantesDirector)
                .HasForeignKey<VotantesDirectores>(vd => vd.DirectoresId);

        }
    }
}
