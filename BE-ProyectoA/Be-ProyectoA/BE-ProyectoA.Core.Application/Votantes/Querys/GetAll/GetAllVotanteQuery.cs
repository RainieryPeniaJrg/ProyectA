using BE_ProyectoA.Core.Application.Votantes.Commons;
using ErrorOr;
using MediatR;

namespace BE_ProyectoA.Core.Application.Votantes.Querys.GetAll
{
    public record GetAllVotanteQuery(): IRequest<ErrorOr<IReadOnlyList<VotantesResponse>>>;
}
