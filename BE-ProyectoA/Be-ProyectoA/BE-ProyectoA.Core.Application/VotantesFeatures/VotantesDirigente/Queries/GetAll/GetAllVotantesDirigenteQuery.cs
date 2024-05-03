using BE_ProyectoA.Core.Application.VotantesFeatures.VotantesDirigente.Common;
using ErrorOr;
using MediatR;

namespace BE_ProyectoA.Core.Application.VotantesFeatures.VotantesDirigente.Queries.GetAll
{
    public record GetAllVotantesDirigenteQuery ():IRequest<ErrorOr<IReadOnlyList<VotantesDirigenteReponse>>>;
    
    
}
