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
         string apellido

    );

    public record VotantesDirigenteResponseDTO(
    Guid Id,
    string NombreCompleto,
    Cedula Cedula,
    NumeroTelefono NumeroTelefono,
    DireccionVotantesDirigenteResponse Direccion,
    bool Activo,
     DirigenteResponse? Dirigente

  );

    public record DireccionVotantesDirigenteResponse(
     string Provincia,
     string Sector
 );
}
