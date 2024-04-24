using BE_ProyectoA.Core.Application.GrupoFeatures.Common;
using ErrorOr;
using MediatR;

namespace BE_ProyectoA.Core.Application.GrupoFeatures.Querys
{
    public record GetAllGruposQuery () : IRequest<ErrorOr<IReadOnlyList<GruposResponse>>>;


}
