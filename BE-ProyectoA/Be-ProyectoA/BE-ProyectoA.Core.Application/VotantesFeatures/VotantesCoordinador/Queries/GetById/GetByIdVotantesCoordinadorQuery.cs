using BE_ProyectoA.Core.Application.VotantesFeatures.VotantesCoordinador.Common;
using ErrorOr;
using MediatR;

namespace BE_ProyectoA.Core.Application.VotantesFeatures.VotantesCoordinador.Queries.GetById
{
    public record GetByIdVotantesCoordinadorQuery (Guid Id): IRequest<ErrorOr<VotantesCoordinadorResponse>>;
    
    
}
