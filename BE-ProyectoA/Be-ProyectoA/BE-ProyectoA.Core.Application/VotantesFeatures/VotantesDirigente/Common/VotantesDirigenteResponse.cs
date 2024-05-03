using BE_ProyectoA.Core.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE_ProyectoA.Core.Application.VotantesFeatures.VotantesDirigente.Common
{
    public record VotantesDirigenteReponse(

        VotantesDirigenteResponseDTO Votantes

        );

    public record DirigenteResponse(
        string Nombre,
        string Apellido
    );

    public record VotantesDirigenteResponseDTO(
    Guid Id,
    string NombreCompleto,
    Cedula Cedula,
    NumeroTelefono NumeroTelefono,
    DireccionVotantesDirigenteResponse Direccion,
    bool Activo,
     DirigenteResponse? CoordinadorGeneral

  );

    public record DireccionVotantesDirigenteResponse(
     string Provincia,
     string Sector
 );
}
