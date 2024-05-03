using BE_ProyectoA.Core.Domain.ValueObjects;

namespace BE_ProyectoA.Core.Application.VotantesFeatures.VotantesSubCoordinadorFeatures.Common
{
    public record VotantesSubCoordinadorResponse

        (

        VotantesSubCoordinadorResponseDTO Votante

        );


    public record SubCoordinadorResponse(
        string Nombre
  
    );

    public record VotantesSubCoordinadorResponseDTO(
         Guid Id,
         string NombreCompleto,
         Cedula Cedula,
         NumeroTelefono NumeroTelefono,
         DireccionVotantesSubCoordinadorResponse Direccion,
         bool Activo,
         SubCoordinadorResponse? SubCoordinador

 );

    public record DireccionVotantesSubCoordinadorResponse(
     string Provincia,
     string Sector
 );
}
