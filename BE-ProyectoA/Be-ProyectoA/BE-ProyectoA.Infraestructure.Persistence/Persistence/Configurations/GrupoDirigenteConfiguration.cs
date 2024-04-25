using BE_ProyectoA.Core.Domain.Entities.GruposEntity;
using BE_ProyectoA.Core.Domain.Entities.GruposEntity.GrupoDirigente;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Reflection.Emit;

namespace BE_ProyectoA.Infraestructure.Persistence.Persistence.Configurations
{
    internal class GrupoDirigenteConfiguration : IEntityTypeConfiguration<GrupoDirigente>
    {
        public void Configure(EntityTypeBuilder<GrupoDirigente> builder)
        {
            builder.HasKey(gd => new { gd.GrupoId, gd.DirigenteId });

            builder.HasOne(gd => gd.Grupo)
                .WithMany()
                .HasForeignKey(gd => gd.GrupoId);

            builder.HasOne(gd => gd.Dirigente)
                .WithMany()
                .HasForeignKey(gd => gd.DirigenteId);
        }
    }
}
