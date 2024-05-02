using BE_ProyectoA.Core.Application.VotantesFeatures.VotantesCoordinador.Common;
using BE_ProyectoA.Core.Application.VotantesFeatures.VotantesDirector.Common;
using ErrorOr;
using MediatR;

namespace BE_ProyectoA.Core.Application.VotantesFeatures.VotantesDirector.Queries.GetAll
{
    public record GetAllVotantesDirectorQuery () : IRequest<ErrorOr<IReadOnlyList<VotantesDirectorResponse>>>;



}
