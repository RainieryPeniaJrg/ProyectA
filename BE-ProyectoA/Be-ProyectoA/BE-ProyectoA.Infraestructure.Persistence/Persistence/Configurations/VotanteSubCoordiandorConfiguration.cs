using BE_ProyectoA.Core.Domain.Entities.Coordinadores;
using BE_ProyectoA.Core.Domain.Entities.Votantes;
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
            builder.Property(sc => sc.VotanteId)
             .HasConversion(
                 cId => cId.Value,
                 value => new VotanteId(value));

            builder.Property(sc => sc.SubCoordinadorId)
                .HasConversion(
                    cId => cId.Value,
                    value => new SubCoordinadoresId(value));

            builder.HasKey(vs => new { vs.VotanteId, vs.SubCoordinadorId });

            builder.HasOne(vs => vs.Votante)
                   .WithMany(v => v.VotantesSubCoordinador)
                   .HasForeignKey(vs => vs.VotanteId)
                   .OnDelete(DeleteBehavior.NoAction);

            builder.HasOne(vs => vs.SubCoordinador)
                   .WithMany()
                   .HasForeignKey(vs => vs.SubCoordinadorId)
                   .OnDelete(DeleteBehavior.NoAction);

        }
    }
}
