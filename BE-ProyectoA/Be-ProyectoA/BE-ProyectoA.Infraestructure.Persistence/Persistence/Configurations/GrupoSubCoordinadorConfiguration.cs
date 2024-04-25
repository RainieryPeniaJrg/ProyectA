using BE_ProyectoA.Core.Domain.Entities.GruposEntity.GrupoSubCoordinador;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BE_ProyectoA.Infraestructure.Persistence.Persistence.Configurations
{
    internal class GrupoSubCoordinadorConfiguration : IEntityTypeConfiguration<GrupoSubCoordinador>
    {
        public void Configure(EntityTypeBuilder<GrupoSubCoordinador> builder)
        {
            builder.HasKey(gs => new { gs.GrupoId, gs.SubCoordinadorId });

            builder.HasOne(gs => gs.Grupo)
                .WithMany()
                .HasForeignKey(gs => gs.GrupoId);

            builder.HasOne(gs => gs.SubCoordinador)
                .WithMany()
                .HasForeignKey(gs => gs.SubCoordinadorId);
        }
    }
}
