using BE_ProyectoA.Core.Application.Votantes.Commons;
using ErrorOr;
using MediatR;

namespace BE_ProyectoA.Core.Application.Votantes.Querys.GetById
{
    public record GetByIdVotantesQuery(Guid Id) : IRequest<ErrorOr<VotantesResponse>>;
    
    
}
