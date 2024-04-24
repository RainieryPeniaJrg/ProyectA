using BE_ProyectoA.Core.Application.VotantesFeatures.Commons;
using ErrorOr;
using MediatR;

namespace BE_ProyectoA.Core.Application.VotantesFeatures.Querys.GetById
{
    public record GetByIdVotantesQuery(Guid Id) : IRequest<ErrorOr<VotantesResponse>>;


}
