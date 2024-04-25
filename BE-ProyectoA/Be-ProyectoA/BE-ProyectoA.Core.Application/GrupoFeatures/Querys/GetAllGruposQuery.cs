using BE_ProyectoA.Core.Application.GrupoFeatures.Common;
using BE_ProyectoA.Core.Application.VotantesFeatures.Commons;
using BE_ProyectoA.Core.Domain.Entities.GruposEntity;
using ErrorOr;
using MediatR;


namespace BE_ProyectoA.Core.Application.GrupoFeatures.Querys
{
    public class GetAllGruposQuery : IRequest<ErrorOr<IReadOnlyList<GrupoResponse>>>
    {
    }

}
