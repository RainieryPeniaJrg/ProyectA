using BE_ProyectoA.Core.Application.VotantesFeatures.Commons;
using BE_ProyectoA.Core.Domain.ValueObjects;
using ErrorOr;
using MediatR;

namespace BE_ProyectoA.Core.Application.VotantesFeatures.Querys.GetByCedulaQuery
{
    public record GetByCedulaQuery(string Cedula) : IRequest<ErrorOr<VotantesResponse>>;

}
