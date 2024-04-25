namespace BE_ProyectoA.Core.Application.GrupoFeatures.Common
{
    public record GrupoResponse(
     Guid Id,
     string NombreGrupo,
     List<DirigenteMultiplicadorResponse> DirigentesMultiplicadores,
     CoordinadorGeneralResponse CoordinadorGeneral,
     List<SubCoordinadorResponse> SubCoordinadores,
     bool Active
 );

    public record DirigenteMultiplicadorResponse(
        Guid Id,
        string NombreCompleto
    );

    public record CoordinadorGeneralResponse(
        Guid Id,
        string NombreCompleto
    );

    public record SubCoordinadorResponse(
        Guid Id,
        string NombreCompleto
    );
}
