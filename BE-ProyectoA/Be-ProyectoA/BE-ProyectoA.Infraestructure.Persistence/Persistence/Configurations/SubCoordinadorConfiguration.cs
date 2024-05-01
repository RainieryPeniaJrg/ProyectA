using BE_ProyectoA.Core.Domain.Entities.Coordinadores;
using BE_ProyectoA.Core.Domain.Entities.CoordinadorGeneral;
using BE_ProyectoA.Core.Domain.ValueObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BE_ProyectoA.Infraestructure.Persistence.Persistence.Configurations
{
    public class SubCoordinadorConfiguration : IEntityTypeConfiguration<SubCoordinadores>
    {
        public void Configure(EntityTypeBuilder<SubCoordinadores> builder)
        {
            builder.HasKey(sc => sc.Id);

            builder.Property(sc => sc.Id)
                .HasConversion(
                    cId => cId.Value,
                    value => new SubCoordinadoresId(value));

            builder.Property(sc => sc.NumeroTelefono)
                .HasConversion(
                    numeroTelefono => numeroTelefono.Value,
                    value => NumeroTelefono.Create(value)!)
                .HasMaxLength(20).IsRequired(false);

            builder.Property(sc => sc.Cedula)
                .HasConversion(
                    cedula => cedula.Value,
                    value => Cedula.Create(value)!)
                .HasMaxLength(20);

            builder.Property(d => d.CantidadVotantes)
              .HasConversion(
                  cedula => cedula.Value,
                  value => CantidadVotos.Create(value)!);

            builder.Ignore(sc => sc.VotantesSubCoordinador);

            builder.Property(sc => sc.Activo);

            builder.Property(sc => sc.CantidadVotantes);

            builder.OwnsOne(sc => sc.Direccion, direccionBuilder =>
            {
                direccionBuilder.Property(d => d.Provincia).HasMaxLength(50);
                direccionBuilder.Property(d => d.Sector).HasMaxLength(50);
                direccionBuilder.Property(d => d.CasaElectoral);
            });

            builder.Property(sc => sc.Nombre).HasMaxLength(50);
            builder.Property(sc => sc.Apellido).HasMaxLength(50);

            builder.Ignore(sc => sc.NombreCompleto);

            builder.HasOne(sc => sc.Coordinadores)
                .WithMany(c => c.SubCoordinadores)
                .HasForeignKey(sc => sc.CoordinadorsGeneralesId)
                .OnDelete(DeleteBehavior.NoAction);

            builder.HasMany(c => c.Votantes)
            .WithOne(v => v.SubCoordinador)
            .HasForeignKey(v => v.SubCoordinadorId)
            .OnDelete(DeleteBehavior.Restrict)
            .IsRequired(false);
        }
    }
}
