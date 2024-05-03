using BE_ProyectoA.Core.Domain.ValueObjects;

namespace BE_ProyectoA.Core.Application.DirigentesFeatures.Commom
{
    public record DirigenteResponse
       (
           Guid Id,
           string NombreCompleto,
           CantidadVotos CantidadVotantes,
           Cedula Cedula,
           NumeroTelefono NumeroTelefono,
           DireccionResponseDirigente Direccion,
           CoordinadorResponse SubCoordinador,
           bool Activo
       );
    public record DireccionResponseDirigente

       (string Provincia,
         string Sector,
         string CasaElectoral
       );

    public record CoordinadorResponse
     (
         Guid Id,
         string NombreCompleto,
         CantidadVotos CantidadVotantes,
         Cedula Cedula,
         NumeroTelefono NumeroTelefono,

         bool Activo
     );






}
