using ErrorOr;
using MediatR;

namespace BE_ProyectoA.Core.Application.CoordinadoresGeneralesFeatures.Commands.Delete
{
    public record DeleteCoordinadorCommand(Guid Id): IRequest<ErrorOr<Unit>>;
    
}
