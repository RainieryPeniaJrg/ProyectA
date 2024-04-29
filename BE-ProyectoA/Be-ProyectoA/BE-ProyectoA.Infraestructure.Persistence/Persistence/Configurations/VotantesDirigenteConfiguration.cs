using BE_ProyectoA.Core.Domain.Entities.Votantes.VotantesDirector;
using BE_ProyectoA.Core.Domain.Entities.Votantes.VotantesDirigentesEntity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE_ProyectoA.Infraestructure.Persistence.Persistence.Configurations
{
    internal class VotantesDirigenteConfiguration : IEntityTypeConfiguration<VotantesDirigentes>
    {
        public void Configure(EntityTypeBuilder<VotantesDirigentes> builder)
        {
            builder.HasKey(gs => new { gs.VotanteId, gs.DirigentesMultiplicadoresId });

            builder
            .HasOne(vd => vd.Votante)
            .WithOne(v => v.VotantesDirigentes)
            .HasForeignKey<VotantesDirigentes>(vd => vd.VotanteId);

            builder
                .HasOne(vd => vd.Dirigentes)
                .WithOne(d => d.VotantesDirigentes)
                .HasForeignKey<VotantesDirigentes>(vd => vd.DirigentesMultiplicadoresId);
        }
    }
}
