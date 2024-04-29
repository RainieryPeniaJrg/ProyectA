using BE_ProyectoA.Core.Domain.Entities.Votantes.VotantesDirector;
using BE_ProyectoA.Core.Domain.Entities.Votantes.VotantesSubCoordinadores;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE_ProyectoA.Infraestructure.Persistence.Persistence.Configurations
{
    internal class VotanteSubCoordiandorConfiguration : IEntityTypeConfiguration<VotantesSubCoordinador>
    {
        public void Configure(EntityTypeBuilder<VotantesSubCoordinador> builder)
        {
            builder.HasKey(gs => new { gs.VotanteId, gs.SubCoordinadorId });

            builder
            .HasOne(vd => vd.Votante)
            .WithOne(v => v.VotantesSubCoordinador)
            .HasForeignKey<VotantesSubCoordinador>(vd => vd.VotanteId);

            builder
                .HasOne(vd => vd.SubCoordinadores)
                .WithOne(sc=>sc.VotantesSubCoordinador)
                .HasForeignKey<VotantesSubCoordinador>(vd => vd.SubCoordinadorId);
        }
    }
}
