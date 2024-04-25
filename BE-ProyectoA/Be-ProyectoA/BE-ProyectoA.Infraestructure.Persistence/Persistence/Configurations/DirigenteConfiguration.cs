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

            builder.Property(d => d.Id)
                .HasConversion(
                    dId => dId.Value,
                    value => new DirigentesMultiplicadoresId(value));

            builder.Property(d => d.NumeroTelefono)
                .HasConversion(
                    numeroTelefono => numeroTelefono.Value,
                    value => NumeroTelefono.Create(value)!)
                .HasMaxLength(20);

            builder.Property(d => d.Cedula)
                .HasConversion(
                    cedula => cedula.Value,
                    value => Cedula.Create(value)!)
                .HasMaxLength(20);


            builder.Property(d => d.CantidadVotantes)
                .HasConversion(
                    cedula => cedula.Value,
                    value => CantidadVotos.Create(value)!);
                


            builder.Property(d => d.Activo);

            builder.Property(d => d.CantidadVotantes);

            builder.OwnsOne(d => d.Direccion, direccionBuilder =>
            {
                direccionBuilder.Property(d => d.Provincia).HasMaxLength(30);
                direccionBuilder.Property(d => d.Sector).HasMaxLength(30);
                direccionBuilder.Property(d => d.CasaElectoral);
            });


            builder.Property(d => d.Nombre).HasMaxLength(30);
            builder.Property(d => d.Apellido).HasMaxLength(30);

            builder.Ignore(d => d.NombreCompleto);

            builder.HasOne(d => d.SubCoordinadores)
                .WithMany(c => c.DirigentesMultiplicadores)
                .HasForeignKey(d => d.SubCoordinadoresId)
                .OnDelete(DeleteBehavior.NoAction); // Especifica cómo manejar las eliminaciones

            builder.HasMany(c => c.Votantes)
              .WithOne(v => v.Dirigente)
               .HasForeignKey(v => v.DirigenteId)
              .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
