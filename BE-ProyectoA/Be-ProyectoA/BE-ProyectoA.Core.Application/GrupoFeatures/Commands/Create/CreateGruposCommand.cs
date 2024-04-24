using ErrorOr;
using MediatR;

namespace BE_ProyectoA.Core.Application.GrupoFeatures.Commands.Create
{
    public record CreateGruposCommand
 
        (
      
         string NombreGrupo,
         Guid DirigentesMultiplicadoresId,
         Guid SubCoordinadoresId,
         Guid CoordinadoresGeneralesId,
        bool Active
        
        )
        : IRequest<ErrorOr<Unit>>;
   
}
