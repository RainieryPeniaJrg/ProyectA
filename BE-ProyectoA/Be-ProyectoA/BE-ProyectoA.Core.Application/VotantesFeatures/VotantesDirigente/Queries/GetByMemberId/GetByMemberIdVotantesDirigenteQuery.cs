using BE_ProyectoA.Core.Application.VotantesFeatures.VotantesDirigente.Common;
using ErrorOr;
using MediatR;

namespace BE_ProyectoA.Core.Application.VotantesFeatures.VotantesDirigente.Queries.GetByMemberId
{
    public record GetByMemberIdVotantesDirigenteQuery(Guid Id): IRequest<ErrorOr<IReadOnlyList<VotantesDirigenteReponse>>>;
    
}
