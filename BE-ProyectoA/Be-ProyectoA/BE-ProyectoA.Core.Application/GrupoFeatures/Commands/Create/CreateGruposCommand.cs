using ErrorOr;
using MediatR;

namespace BE_ProyectoA.Core.Application.GrupoFeatures.Commands.Create
{
    public record CreateGruposCommand
 
        (

          string NombreGrupo,
        ICollection<Guid> DirigentesMultiplicadoresIds,
        ICollection<Guid> CoordinadoresGeneralesIds,
        ICollection<Guid> SubCoordinadoresIds,
        bool Active 
        
        )
        : IRequest<ErrorOr<Unit>>;
   
}
