﻿using BE_ProyectoA.Core.Domain.Entities.Coordinadores;
using BE_ProyectoA.Core.Domain.Entities.CoordinadorGeneral;
using BE_ProyectoA.Core.Domain.ValueObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BE_ProyectoA.Infraestructure.Persistence.Persistence.Configurations
{
    internal class SubCoordinadorConfiguration : IEntityTypeConfiguration<SubCoordinadores>
    {
        public void Configure(EntityTypeBuilder<SubCoordinadores> builder)
        {
            builder.HasKey(sc => sc.Id);

            builder.Property(sc => sc.Id).HasConversion(
                cId => cId.Value,
                value => new SubCoordinadoresId(value));

            builder.Property(sc => sc.NumeroTelefono).HasConversion(
              numeroTelefono => numeroTelefono.Value, value => NumeroTelefono.Create(value)!)
              .HasMaxLength(20);


            builder.Property(sc => sc.Cedula).HasConversion(
               cedula => cedula.Value, value => Cedula.Create(value)!)
               .HasMaxLength(20);

            builder.Property(sc => sc.Activo);

            builder.Property(sc => sc.CantidadVotantes);

            builder.OwnsOne(sc => sc.Direccion, direccionBuilder =>
            {
                direccionBuilder.Property(d => d.Provincia).HasMaxLength(30);
                direccionBuilder.Property(d => d.Sector).HasMaxLength(30);

            });

            builder.Property(sc => sc.Nombre).HasMaxLength(30);

            builder.Property(sc => sc.Apellido).HasMaxLength(30);

            builder.Ignore(sc => sc.NombreCompleto);
        }
    }
}
