using BE_ProyectoA.Core.Application.GrupoFeatures.Common;
using BE_ProyectoA.Core.Domain.Entities.GruposEntity;
using ErrorOr;
using MediatR;

namespace BE_ProyectoA.Core.Application.GrupoFeatures.Querys
{
    public class GetAllGruposQueryHandler : IRequestHandler<GetAllGruposQuery, ErrorOr<IReadOnlyList<GruposResponse>>>
    {
        private readonly IGruposRepository _gruposRepository;

        public GetAllGruposQueryHandler(IGruposRepository gruposRepository)
        {
            _gruposRepository = gruposRepository;
        }

        public async Task<ErrorOr<IReadOnlyList<GruposResponse>>> Handle(GetAllGruposQuery query, CancellationToken cancellationToken)
        {
           var grupos = await _gruposRepository.GetAllGrupos(cancellationToken);


            var gruposResponse = grupos.Select(g => new GruposResponse(g.NombreGrupo,
                new CoordinadorGeneralResponse(
                    g.CoordinadoresGenerales.Id.Value,
                    g.CoordinadoresGenerales.NombreCompleto,
                    g.CoordinadoresGenerales.CantidadVotantes,
                    g.CoordinadoresGenerales.Cedula,
                    g.CoordinadoresGenerales.NumeroTelefono,
                    g.CoordinadoresGenerales.Direccion,
                    g.CoordinadoresGenerales.Activo),
                new SubCoordinadorResponse(g.SubCoordinadores.Id.Value,
                g.SubCoordinadores.NombreCompleto, g.SubCoordinadores.CantidadVotantes,
                g.SubCoordinadores.Cedula, g.SubCoordinadores.NumeroTelefono,
                g.SubCoordinadores.Direccion, g.SubCoordinadores.Activo),
                new DirigenteResponse(g.
                DirigentesMultiplicadores.Id.Value,
                g.DirigentesMultiplicadores.NombreCompleto,
                g.DirigentesMultiplicadores.CantidadVotantes,
                g.DirigentesMultiplicadores.Cedula, g.DirigentesMultiplicadores
                .NumeroTelefono, g.DirigentesMultiplicadores.Direccion,
                g.DirigentesMultiplicadores.Activo))).ToList();

            return gruposResponse;



                
        }
    }
}

