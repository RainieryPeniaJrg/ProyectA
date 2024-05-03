using BE_ProyectoA.Core.Application.VotantesFeatures.VotantesCoordinador.Common;
using ErrorOr;
using MediatR;

namespace BE_ProyectoA.Core.Application.VotantesFeatures.VotantesCoordinador.Queries.GetByMember
{
    public record GetByMemberIdVotantesCoordinadorQuery (Guid Id) : IRequest<ErrorOr<IReadOnlyList<VotantesCoordinadorResponse>>>;
   
}
