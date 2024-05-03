using BE_ProyectoA.Core.Application.VotantesFeatures.VotantesDirector.Common;
using ErrorOr;
using MediatR;

namespace BE_ProyectoA.Core.Application.VotantesFeatures.VotantesDirector.Queries.GetById
{
    public record GetByIdVotantesDirectorQuery (Guid Id): IRequest<ErrorOr<VotantesDirectorResponse>>;
   
}
