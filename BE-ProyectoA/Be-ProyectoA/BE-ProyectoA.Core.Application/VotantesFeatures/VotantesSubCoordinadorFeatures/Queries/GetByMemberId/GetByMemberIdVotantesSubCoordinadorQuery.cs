using BE_ProyectoA.Core.Application.VotantesFeatures.VotantesSubCoordinadorFeatures.Common;
using ErrorOr;
using MediatR;

namespace BE_ProyectoA.Core.Application.VotantesFeatures.VotantesSubCoordinadorFeatures.Queries.GetByMemberId
{
    public record GetByMemberIdVotantesSubCoordinadorQuery (Guid Id): IRequest<ErrorOr<IReadOnlyList<VotantesSubCoordinadorResponse>>>;
   
}
