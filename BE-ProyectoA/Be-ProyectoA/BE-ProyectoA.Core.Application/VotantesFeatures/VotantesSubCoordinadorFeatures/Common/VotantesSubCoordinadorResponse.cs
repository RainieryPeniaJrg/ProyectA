using BE_ProyectoA.Core.Domain.ValueObjects;

namespace BE_ProyectoA.Core.Application.VotantesFeatures.VotantesSubCoordinadorFeatures.Common
{
    public record VotantesSubCoordinadorResponse

        (

        VotantesResponse Votante,
        SubCoordinadorResponse SubCoordinador

        );


    public record SubCoordinadorResponse(
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
         SubCoordinadorResponse? CoordinadorGeneral

 );

    public record DireccionResponse(
     string Provincia,
     string Sector
 );
}
