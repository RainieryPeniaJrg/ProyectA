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
            builder.HasKey(gs => new { gs.VotanteId, gs.CoordinadorId });

            builder
            .HasOne(vd => vd.Votante)
            .WithOne(v => v.VotantesCoordinadoresGenerales)
            .HasForeignKey<VotantesCoordinadoresGenerales>(vd => vd.VotanteId);

            builder
                .HasOne(vd => vd.Coordinador)
                .WithOne(d => d.VotantesCoordinadoresGenerales)
                .HasForeignKey<VotantesCoordinadoresGenerales>(vd => vd.CoordinadorId);
        }
    }
}
