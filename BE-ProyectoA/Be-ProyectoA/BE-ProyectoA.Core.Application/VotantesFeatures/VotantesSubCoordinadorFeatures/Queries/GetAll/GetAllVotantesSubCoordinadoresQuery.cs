using BE_ProyectoA.Core.Application.VotantesFeatures.VotantesSubCoordinadorFeatures.Common;
using ErrorOr;
using MediatR;

namespace BE_ProyectoA.Core.Application.VotantesFeatures.VotantesSubCoordinadorFeatures.Queries.GetAll
{
    public record GetAllVotantesSubCoordinadoresQuery (): IRequest<ErrorOr<IReadOnlyList<VotantesSubCoordinadorResponse>>>;
    
}
