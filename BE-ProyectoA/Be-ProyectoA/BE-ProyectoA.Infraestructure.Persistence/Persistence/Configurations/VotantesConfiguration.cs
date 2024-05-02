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

            builder.Property(v => v.Id)
                .HasConversion(
                    cId => cId.Value,
                    value => new VotanteId(value));

            builder.Property(v => v.NumeroTelefono)
                .HasConversion(
                    numeroTelefono => numeroTelefono.Value,
                    value => NumeroTelefono.Create(value)!)
                .HasMaxLength(20).IsRequired(false);

            builder.Property(v => v.Cedula)
                .HasConversion(
                    cedula => cedula.Value,
                    value => Cedula.Create(value)!)
                .HasMaxLength(20);

            builder.Property(v => v.Activo);

            builder.OwnsOne(v => v.Direccion, direccionBuilder =>
            {
                direccionBuilder.Property(d => d.Provincia).HasMaxLength(50).IsRequired(false);
                direccionBuilder.Property(d => d.Sector).HasMaxLength(50).IsRequired(false);
                direccionBuilder.Property(d => d.CasaElectoral).IsRequired(false);
            });


            builder.Property(v => v.CoordinadorGeneralId).IsRequired(false);

            builder.Property(v => v.DirigenteId).IsRequired(false);

            builder.Property(v => v.SubCoordinadorId).IsRequired(false);

            builder.Property(v => v.DirectorId).IsRequired(false);

            builder.Property(v => v.Nombre).HasMaxLength(50);
            builder.Property(v => v.Apellido).HasMaxLength(50);

            builder.Ignore(v => v.NombreCompleto);
        }
    }
}
