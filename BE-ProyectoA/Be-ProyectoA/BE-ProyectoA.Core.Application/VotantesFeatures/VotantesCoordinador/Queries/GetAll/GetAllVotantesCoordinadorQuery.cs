using BE_ProyectoA.Core.Application.VotantesFeatures.VotantesCoordinador.Common;
using ErrorOr;
using MediatR;

namespace BE_ProyectoA.Core.Application.VotantesFeatures.VotantesCoordinador.Queries.GetAll
{
    public record GetAllVotantesCoordinadorQuery() : IRequest<ErrorOr<IReadOnlyList<VotantesCoordinadorResponse>>>;
    
    
}
