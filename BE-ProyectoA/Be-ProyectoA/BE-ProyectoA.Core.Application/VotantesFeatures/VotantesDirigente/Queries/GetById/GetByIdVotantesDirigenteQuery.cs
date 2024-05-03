using BE_ProyectoA.Core.Application.VotantesFeatures.VotantesDirigente.Common;
using ErrorOr;
using MediatR;

namespace BE_ProyectoA.Core.Application.VotantesFeatures.VotantesDirigente.Queries.GetById
{
    public record GetByIdVotantesDirigenteQuery(Guid Id) : IRequest<ErrorOr<VotantesDirigenteReponse>>;
    
    
}
