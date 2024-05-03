using BE_ProyectoA.Core.Domain.ValueObjects;

namespace BE_ProyectoA.Core.Application.VotantesFeatures.VotantesDirector.Common
{
    public record VotantesDirectorResponse
        (
         VotantesDirectorResponseDTO Votantes
        );

    public record DirectorResponse(
          string Nombre
 
      );

    public record VotantesDirectorResponseDTO(
    Guid Id,
    string NombreCompleto,
    Cedula Cedula,
    NumeroTelefono NumeroTelefono,
    DireccionVotantesDirectorResponse Direccion,
    bool Activo,
    DirectorResponse? Director

    );

    public record DireccionVotantesDirectorResponse(
     string Provincia,
     string Sector
 );

}
