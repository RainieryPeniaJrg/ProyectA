using BE_ProyectoA.Core.Domain.ValueObjects;

namespace BE_ProyectoA.Core.Application.VotantesFeatures.VotantesDirector.Common
{
    public record VotantesDirectorResponse
        (


        );

    public record DirectorResponse(
          string Nombre,
          string Apellido
      );

    public record VotantesResponse(
    Guid Id,
    string NombreCompleto,
    Cedula Cedula,
    NumeroTelefono NumeroTelefono,
    DireccionResponse Direccion,
    bool Activo,
    DirectorResponse? CoordinadorGeneral

    );

    public record DireccionResponse(
     string Provincia,
     string Sector
 );

}
