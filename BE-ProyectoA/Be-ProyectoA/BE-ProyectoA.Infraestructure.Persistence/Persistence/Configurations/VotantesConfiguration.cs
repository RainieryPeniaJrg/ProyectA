using BE_ProyectoA.Core.Domain.Entities.Coordinadores;
using BE_ProyectoA.Core.Domain.Entities.Votantes;
using BE_ProyectoA.Core.Domain.ValueObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BE_ProyectoA.Infraestructure.Persistence.Persistence.Configurations
{
    internal class VotantesConfiguration : IEntityTypeConfiguration<Votante>
    {
        public void Configure(EntityTypeBuilder<Votante> builder)
        {
            builder.HasKey(v => v.Id);

            builder.Property(v => v.Id).HasConversion(
                cId => cId.Value,
                value => new VotanteId(value));

            builder.Property(v => v.NumeroTelefono).HasConversion(
              numeroTelefono => numeroTelefono.Value, value => NumeroTelefono.Create(value)!)
              .HasMaxLength(20);


            builder.Property(v => v.Cedula).HasConversion(
               cedula => cedula.Value, value => Cedula.Create(value)!)
               .HasMaxLength(20);

            builder.Property(v => v.Activo);


            builder.OwnsOne(v => v.Direccion, direccionBuilder =>
            {
                direccionBuilder.Property(d => d.Provincia).HasMaxLength(30);
                direccionBuilder.Property(d => d.Sector).HasMaxLength(30);

            });

            builder.Property(v => v.Nombre).HasMaxLength(30);

            builder.Property(v => v.Apellido).HasMaxLength(30);

            builder.Ignore(v => v.NombreCompleto);
        }
    }
}
