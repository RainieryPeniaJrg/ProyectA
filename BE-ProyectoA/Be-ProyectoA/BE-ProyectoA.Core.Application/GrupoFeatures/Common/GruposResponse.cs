
using BE_ProyectoA.Core.Domain.ValueObjects;

namespace BE_ProyectoA.Core.Application.GrupoFeatures.Common
{
    public record GruposResponse
        (
        string NombreGrupo,
        CoordinadorGeneralResponse CoordinadorGeneralResponse,
        SubCoordinadorResponse SubCoordinadorResponse,
        DirigenteResponse DirigenteResponse
        );
    
        

    

    public record DirigenteResponse
       (
           Guid Id,
           string NombreCompleto,
           int CantidadVotantes,
           Cedula Cedula,
           NumeroTelefono NumeroTelefono,
           Direccion Direccion,
           bool Activo
       );

    public record SubCoordinadorResponse
   (
       Guid Id,
       string NombreCompleto,
       int CantidadVotantes,
       Cedula Cedula,
       NumeroTelefono NumeroTelefono,
       Direccion Direccion,
       bool Activo
   );

    public record CoordinadorGeneralResponse
    (
        Guid Id,
        string NombreCompleto,
        int CantidadVotantes,
        Cedula Cedula,
        NumeroTelefono NumeroTelefono,
        Direccion Direccion,
        bool Activo
    );
}
