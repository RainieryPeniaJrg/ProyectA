using BE_ProyectoA.Core.Application.CoordinadoresGeneralesFeatures.Common;
using ErrorOr;
using MediatR;

namespace BE_ProyectoA.Core.Application.CoordinadoresGeneralesFeatures.Query.GetAll
{
    public record GetAllCoordinadorGeneralQuery (): IRequest<ErrorOr<IReadOnlyList<CoordinadorGeneralResponse>>>;
    
}
