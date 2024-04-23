using BE_ProyectoA.Core.Domain.Entities.CoordinadorGeneral;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BE_ProyectoA.Infraestructure.Persistence.Persistence.Configurations
{
    public class CoordinadorGeneralConfiguration : IEntityTypeConfiguration<CoordinadoresGenerales>
    {
        public void Configure(EntityTypeBuilder<CoordinadoresGenerales> builder)
        {
           
        }
    }
}
