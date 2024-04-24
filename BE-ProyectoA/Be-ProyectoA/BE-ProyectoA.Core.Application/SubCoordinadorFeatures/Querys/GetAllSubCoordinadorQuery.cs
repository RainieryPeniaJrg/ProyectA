using ErrorOr;
using MediatR;

namespace BE_ProyectoA.Core.Application.SubCoordinadorFeatures.Querys
{
    public record GetAllSubCoordinadorQuery : IRequest<ErrorOr<Unit>>;
   
}
