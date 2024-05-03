using BE_ProyectoA.Core.Application.VotantesFeatures.VotantesSubCoordinadorFeatures.Common;
using BE_ProyectoA.Core.Domain.Entities.Votantes.VotantesSubCoordinadores;
using ErrorOr;
using MediatR;

namespace BE_ProyectoA.Core.Application.VotantesFeatures.VotantesSubCoordinadorFeatures.Queries.GetById
{
    internal class GetByIdVotantesSubCoordinadorQueryHandler : IRequestHandler<GetByIdVotantesSubCoordinadorQuery, ErrorOr<VotantesSubCoordinadorResponse>>
    {
        private readonly IVotantesSubCoordiandoresRepository _votanteSubCoordinadorRepository;

        public GetByIdVotantesSubCoordinadorQueryHandler(IVotantesSubCoordiandoresRepository votanteSubCoordinadorRepository)
        {
            _votanteSubCoordinadorRepository = votanteSubCoordinadorRepository;
        }

        public async Task<ErrorOr<VotantesSubCoordinadorResponse>> Handle(GetByIdVotantesSubCoordinadorQuery request, CancellationToken cancellationToken)
        {
            var votanteSubCoordinador = await _votanteSubCoordinadorRepository.GetByIdWithMembers(request.Id, cancellationToken);

            if (votanteSubCoordinador == null)
            {
               
                return Error.NotFound("VotanteSubCoordinador no encontrado");
            }

            var votanteResponseDTO = new VotantesSubCoordinadorResponseDTO(
                votanteSubCoordinador.VotanteId.Value,
                votanteSubCoordinador.Votante.NombreCompleto,
                votanteSubCoordinador.Votante.Cedula,
                votanteSubCoordinador.Votante.NumeroTelefono,
                new DireccionVotantesSubCoordinadorResponse(
                    votanteSubCoordinador.Votante.Direccion.Provincia,
                    votanteSubCoordinador.Votante.Direccion.Sector
                ),
                votanteSubCoordinador.Votante.Activo,
                votanteSubCoordinador.SubCoordinador != null ? new SubCoordinadorResponse(votanteSubCoordinador.SubCoordinador.Nombre) : null
            );

            var votanteSubCoordinadorResponse = new VotantesSubCoordinadorResponse(votanteResponseDTO);

            return votanteSubCoordinadorResponse;
        }
    }
}

