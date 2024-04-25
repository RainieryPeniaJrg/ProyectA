using BE_ProyectoA.Core.Application.GrupoFeatures.Common;
using BE_ProyectoA.Core.Domain.Entities.GruposEntity;
using ErrorOr;
using MediatR;

namespace BE_ProyectoA.Core.Application.GrupoFeatures.Querys
{
    
        public class GetAllGruposQueryHandler : IRequestHandler<GetAllGruposQuery, ErrorOr<IReadOnlyList<GrupoResponse>>>
    {
        private readonly IGruposRepository _grupoRepository;

        public GetAllGruposQueryHandler(IGruposRepository grupoRepository)
        {
            _grupoRepository = grupoRepository ?? throw new ArgumentNullException(nameof(grupoRepository));
        }

        public async Task<ErrorOr<IReadOnlyList<GrupoResponse>>> Handle(GetAllGruposQuery query, CancellationToken cancellationToken)
        {
            var grupos = await _grupoRepository.GetAllGrupos(cancellationToken);

            var grupoResponses = grupos.Select(grupo => new GrupoResponse(
                grupo.Id.Value,
                grupo.NombreGrupo,
                grupo.DirigentesMultiplicadores?.Select(dm => new DirigenteMultiplicadorResponse(dm.Id.Value, dm.NombreCompleto)).ToList(),
                grupo.CoordinadorGeneral != null ? new CoordinadorGeneralResponse(grupo.CoordinadorGeneral.Id.Value, grupo.CoordinadorGeneral.NombreCompleto) : null,
                grupo.SubCoordinadores?.Select(sc => new SubCoordinadorResponse(sc.Id.Value, sc.NombreCompleto)).ToList(),
                grupo.Active
            )).ToList();

            return grupoResponses;
        }
    }
    }


 