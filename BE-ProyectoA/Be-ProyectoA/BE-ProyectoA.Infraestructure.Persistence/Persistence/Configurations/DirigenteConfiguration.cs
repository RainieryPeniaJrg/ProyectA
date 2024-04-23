using BE_ProyectoA.Core.Domain.Entities.Coordinadores;
using BE_ProyectoA.Core.Domain.Entities.CoordinadorGeneral;
using BE_ProyectoA.Core.Domain.Entities.DirigenteMultiplicador;
using BE_ProyectoA.Core.Domain.ValueObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BE_ProyectoA.Infraestructure.Persistence.Persistence.Configurations
{
    public class DirigenteConfiguration : IEntityTypeConfiguration<DirigentesMultiplicadores>
    {
        public void Configure(EntityTypeBuilder<DirigentesMultiplicadores> builder)
        {
            builder.HasKey(d => d.Id);

            builder.Property(d => d.Id).HasConversion(
                dId => dId.Value,
                value => new DirigentesMultiplicadoresId(value));

            builder.Property(d => d.NumeroTelefono).HasConversion(
              numeroTelefono => numeroTelefono.Value, value => NumeroTelefono.Create(value)!)
              .HasMaxLength(11);


            builder.Property(d => d.Cedula).HasConversion(
               cedula => cedula.Value, value => Cedula.Create(value)!)
               .HasMaxLength(11);

            builder.Property(d => d.Activo);

            builder.Property(d => d.CantidadVotantes);

            builder.OwnsOne(d => d.Direccion, direccionBuilder =>
            {
                direccionBuilder.Property(d => d.Provincia).HasMaxLength(30);
                direccionBuilder.Property(d => d.Sector).HasMaxLength(30);

            });

            builder.Property(d => d.Nombre).HasMaxLength(30);

            builder.Property(d => d.Apellido).HasMaxLength(30);

            builder.Ignore(d => d.NombreCompleto);
        }
    }
}
