using BE_ProyectoA.Core.Application.VotantesFeatures.VotantesDirector.Common;
using ErrorOr;
using MediatR;

namespace BE_ProyectoA.Core.Application.VotantesFeatures.VotantesDirector.Queries.GetByMemberId
{
    public record GetByMemberIdVotantesDirectorQuery(Guid Id) : IRequest<ErrorOr<IReadOnlyList<VotantesDirectorResponse>>>;
  
}
