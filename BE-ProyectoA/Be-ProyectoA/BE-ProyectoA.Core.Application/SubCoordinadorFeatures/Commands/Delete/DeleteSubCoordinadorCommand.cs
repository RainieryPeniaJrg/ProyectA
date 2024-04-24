using ErrorOr;
using MediatR;

namespace BE_ProyectoA.Core.Application.SubCoordinadorFeatures.Commands.Delete
{
    public record DeleteSubCoordinadorCommand(Guid Id) : IRequest<ErrorOr<Unit>>;

}
