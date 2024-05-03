using BE_ProyectoA.Core.Application.VotantesFeatures.VotantesSubCoordinadorFeatures.Common;
using ErrorOr;
using MediatR;

namespace BE_ProyectoA.Core.Application.VotantesFeatures.VotantesSubCoordinadorFeatures.Queries.GetById
{
    public record GetByIdVotantesSubCoordinadorQuery (Guid Id) : IRequest<ErrorOr<VotantesSubCoordinadorResponse>>;
    
    
}
