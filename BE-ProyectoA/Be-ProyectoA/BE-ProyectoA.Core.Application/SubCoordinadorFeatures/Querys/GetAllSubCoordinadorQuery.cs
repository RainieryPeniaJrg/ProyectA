
using BE_ProyectoA.Core.Application.SubCoordinadorFeatures.Common;
using ErrorOr;
using MediatR;

namespace BE_ProyectoA.Core.Application.SubCoordinadorFeatures.Querys
{
    public record GetAllSubCoordinadorQuery : IRequest<ErrorOr<IReadOnlyList<SubCoordinadorResponse>>>;

}
