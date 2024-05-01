using BE_ProyectoA.Core.Domain.Entities.Coordinadores;
using BE_ProyectoA.Core.Domain.Entities.CoordinadorGeneral;
using BE_ProyectoA.Core.Domain.Entities.Director;
using BE_ProyectoA.Core.Domain.Entities.DirigenteMultiplicador;
using BE_ProyectoA.Core.Domain.Entities.Votantes.VotantesCoordinadorGeneral;
using BE_ProyectoA.Core.Domain.ValueObjects;

namespace BE_ProyectoA.Core.Application.VotantesFeatures.Commons
{
    public record VotantesResponse(
     Guid Id,
     string NombreCompleto,
     Cedula Cedula,
     NumeroTelefono NumeroTelefono,
     DireccionResponse Direccion,
     bool Activo,
     IReadOnlyList<CoordinadoresGeneralesId> VotantesCoordinadoresGenerales
 );

    public record DireccionResponse(
        string Provincia,
        string Sector
    );

    public record DirectorResponse(
        string Nombre,
        string Apellido
    );

    public record SubCoordinadorResponse(
        string Nombre,
        string Apellido
    );

    public record CoordinadorGeneralResponse(
        string Nombre,
        string Apellido
    );

    public record DirigenteMultiplicadorResponse(
        string Nombre,
        string Apellido
    );


}
