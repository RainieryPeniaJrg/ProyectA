using BE_ProyectoA.Core.Application.VotantesFeatures.Commons;
using ErrorOr;
using MediatR;

namespace BE_ProyectoA.Core.Application.VotantesFeatures.Querys.GetAll
{
    public record GetAllVotanteQuery() : IRequest<ErrorOr<IReadOnlyList<VotantesResponse>>>;
}
