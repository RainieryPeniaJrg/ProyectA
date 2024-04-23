using BE_ProyectoA.Core.Application.Votantes.Commons;
using BE_ProyectoA.Core.Domain.ValueObjects;
using ErrorOr;
using MediatR;

namespace BE_ProyectoA.Core.Application.Votantes.Querys.GetByCedulaQuery
{
    public record GetByCedulaQuery (string Cedula): IRequest<ErrorOr<VotantesResponse>>;
    
}
