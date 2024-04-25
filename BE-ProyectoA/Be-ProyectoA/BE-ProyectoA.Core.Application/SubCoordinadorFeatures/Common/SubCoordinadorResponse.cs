using BE_ProyectoA.Core.Domain.ValueObjects;

namespace BE_ProyectoA.Core.Application.SubCoordinadorFeatures.Common
{
    public record SubCoordinadorResponse
      (
          Guid Id,
          string NombreCompleto,
          CantidadVotos CantidadVotantes,
          Cedula Cedula,
          NumeroTelefono NumeroTelefono,
          DireccionResponseCoordinador Direccion,
          GerenteGeneralResponsse Coordinador,
          bool Activo
      );
    public record DireccionResponseCoordinador

       (string Provincia,
         string Sector,
         int CasaElectoral
       );

    public record GerenteGeneralResponsse
     (
         Guid Id,
         string NombreCompleto,
         CantidadVotos CantidadVotantes,
         Cedula Cedula,
         NumeroTelefono NumeroTelefono,
         bool Activo
     );

}
