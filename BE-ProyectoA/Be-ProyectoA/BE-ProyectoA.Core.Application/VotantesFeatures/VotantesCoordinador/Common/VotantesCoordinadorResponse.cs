using BE_ProyectoA.Core.Domain.Entities.CoordinadorGeneral;
using BE_ProyectoA.Core.Domain.Entities.Votantes;
using BE_ProyectoA.Core.Domain.ValueObjects;

namespace BE_ProyectoA.Core.Application.VotantesFeatures.VotantesCoordinador.Common
{
    public record VotantesCoordinadorResponse
        (

         VotantesResponse Votante
       
        
        );
    public record VotantesResponse(
          Guid Id,
          string NombreCompleto,
          Cedula Cedula,
          NumeroTelefono NumeroTelefono,
          DireccionResponse Direccion,
          bool Activo,
          CoordinadorGeneralResponse? CoordinadorGeneral
      
          );

    public record DireccionResponse(
     string Provincia,
     string Sector
 );

    public record CoordinadorGeneralResponse(
      string Nombre,
      string Apellido
  );






}
