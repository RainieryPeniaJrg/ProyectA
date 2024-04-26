using BE_ProyectoA.Core.Domain.Entities.Director;
using BE_ProyectoA.Core.Domain.ValueObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BE_ProyectoA.Infraestructure.Persistence.Persistence.Configurations
{
    public class DirectorConfiguration : IEntityTypeConfiguration<Directores>
    {
        public void Configure(EntityTypeBuilder<Directores> builder)
        {
            builder.HasKey(D => D.Id);

            builder.Property(D => D.Id)
                .HasConversion(
                    DirectoresId => DirectoresId.Value,
                    value => new DirectoresId(value));

            builder.Property(D => D.NumeroTelefono)
                .HasConversion(
                    numeroTelefono => numeroTelefono.Value,
                    value => NumeroTelefono.Create(value)!)
                .HasMaxLength(20);

            builder.Property(D => D.Nombre).HasMaxLength(50);
            builder.Property(D => D.Apellido).HasMaxLength(50);

            builder.Ignore(D => D.NombreCompleto);

            builder.Property(D => D.Cedula)
                .HasConversion(
                    cedula => cedula.Value,
                    value => Cedula.Create(value)!)
                .HasMaxLength(20);

            builder.Property(D => D.Activo);

            builder.Property(d => d.CantidadVotantes)
                 .HasConversion(
                     cedula => cedula.Value,
                     value => CantidadVotos.Create(value)!);

            builder.HasMany(c => c.Votantes)
              .WithOne(v => v.Director)
              .HasForeignKey(v => v.DirectorId)
              .OnDelete(DeleteBehavior.Restrict)
              .IsRequired(false);
        }
    }
}
