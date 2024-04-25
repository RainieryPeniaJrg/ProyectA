using BE_ProyectoA.Core.Domain.Entities.GruposEntity;
using BE_ProyectoA.Core.Domain.Entities.GruposEntity.GrupoDirigente;
using BE_ProyectoA.Core.Domain.Entities.GruposEntity.GrupoSubCoordinador;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BE_ProyectoA.Infraestructure.Persistence.Persistence.Configurations
{
    internal class GruposConfiguration : IEntityTypeConfiguration<Grupos>
    {
        public void Configure(EntityTypeBuilder<Grupos> builder)
        {
            builder.HasKey(g => g.Id);

            builder.Property(g => g.Id)
                .HasConversion(
                    grupoId => grupoId.Value,
                    value => new GruposId(value)
                );

            builder.HasMany(g => g.DirigentesMultiplicadores)
                .WithMany(d => d.Grupos)
                .UsingEntity<GrupoDirigente>(
                    j => j.HasOne(gd => gd.Dirigente).WithMany(),
                    j => j.HasOne(gd => gd.Grupo).WithMany()
                );

            builder.HasMany(g => g.SubCoordinadores)
                .WithMany(s => s.Grupos)
                .UsingEntity<GrupoSubCoordinador>(
                    j => j.HasOne(gs => gs.SubCoordinador).WithMany(),
                    j => j.HasOne(gs => gs.Grupo).WithMany()
                );

            builder.HasOne(g => g.CoordinadorGeneral)
                .WithMany()
                .HasForeignKey(g => g.CoordinadoresGeneralId)
                .OnDelete(DeleteBehavior.NoAction); // Especifica cómo manejar las eliminaciones
        }
    }
}
