using ErrorOr;
using MediatR;

namespace BE_ProyectoA.Core.Application.Director.Commands.Delete
{
    public record DeleteDirectorCommand(Guid Id): IRequest<ErrorOr<Unit>>;
}
