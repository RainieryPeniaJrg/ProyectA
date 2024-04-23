using BE_ProyectoA.Core.Domain.Entities.Director;
using BE_ProyectoA.Core.Domain.ValueObjects;

namespace BE_ProyectoA.Core.Application.Director.Common
{
    
    public record DirectorResponse
        (
            Guid Id,
            string NombreCompleto,
            int CantidadVotantes,
            Cedula Cedula,
            NumeroTelefono NumeroTelefono,
            bool Activo
        );

     public record DireccionResponse

        ( string Provincia,
          string Sector
        );
    
      

    
}
