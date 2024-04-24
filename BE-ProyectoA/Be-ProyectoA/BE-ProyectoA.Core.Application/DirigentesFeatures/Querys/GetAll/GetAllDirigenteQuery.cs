
using BE_ProyectoA.Core.Application.DirigentesFeatures.Commom;
using ErrorOr;
using MediatR;

namespace BE_ProyectoA.Core.Application.DirigentesFeatures.Querys.GetAll
{
    public record GetAllDirigenteQuery () : IRequest<ErrorOr<IReadOnlyList<DirigenteResponse>>>;


}
