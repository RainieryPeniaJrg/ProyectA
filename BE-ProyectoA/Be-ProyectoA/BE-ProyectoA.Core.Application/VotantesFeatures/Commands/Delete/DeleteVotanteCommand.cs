using ErrorOr;
using MediatR;

namespace BE_ProyectoA.Core.Application.VotantesFeatures.Commands.Delete
{
    public record DeleteVotanteCommand(Guid Id) : IRequest<ErrorOr<Unit>>;



}
