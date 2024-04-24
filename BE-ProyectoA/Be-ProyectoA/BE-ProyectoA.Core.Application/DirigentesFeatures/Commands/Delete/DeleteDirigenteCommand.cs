using ErrorOr;
using MediatR;

namespace BE_ProyectoA.Core.Application.DirigentesFeatures.Commands.Delete
{
    public record DeleteDirigenteCommand
        (
        Guid Id
        
        ):IRequest<ErrorOr<Unit>>;
   
}
