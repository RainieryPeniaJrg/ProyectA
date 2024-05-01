using BE_ProyectoA.Core.Domain.Entities.CoordinadorGeneral;
using BE_ProyectoA.Core.Domain.ValueObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BE_ProyectoA.Infraestructure.Persistence.Persistence.Configurations
{
    public class CoordinadorGeneralConfiguration : IEntityTypeConfiguration<CoordinadoresGenerales>
    {
        public void Configure(EntityTypeBuilder<CoordinadoresGenerales> builder)
        {
            builder.HasKey(c => c.Id);

            builder.Property(c => c.Id)
                .HasConversion(
                    cId => cId.Value,
                    value => new CoordinadoresGeneralesId(value));

            builder.Property(c => c.NumeroTelefono)
                .HasConversion(
                    numeroTelefono => numeroTelefono.Value,
                    value => NumeroTelefono.Create(value)!)
                .HasMaxLength(20);

            builder.Property(c => c.Cedula)
                .HasConversion(
                    cedula => cedula.Value,
                    value => Cedula.Create(value)!)
                .HasMaxLength(20);

            builder.Property(c => c.Activo);

            builder.OwnsOne(c => c.Direccion, direccionBuilder =>
            {
                direccionBuilder.Property(d => d.Provincia).HasMaxLength(30);
                direccionBuilder.Property(d => d.Sector).HasMaxLength(30);
                direccionBuilder.Property(d => d.CasaElectoral);
            });

            builder.Ignore(c => c.VotantesCoordinadoresGenerales);

            builder.Property(d => d.CantidadVotantes)
                .HasConversion(
                    cedula => cedula.Value,
                    value => CantidadVotos.Create(value)!).IsRequired(false);

            builder.Property(c => c.Nombre).HasMaxLength(50);
            builder.Property(c => c.Apellido).HasMaxLength(50);

            builder.Ignore(c => c.NombreCompleto);
        }
    }
}
