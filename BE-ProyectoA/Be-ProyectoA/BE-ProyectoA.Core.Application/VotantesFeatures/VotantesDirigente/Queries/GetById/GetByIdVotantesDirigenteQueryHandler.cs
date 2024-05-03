using BE_ProyectoA.Core.Application.VotantesFeatures.VotantesDirigente.Common;
using BE_ProyectoA.Core.Application.VotantesFeatures.VotantesSubCoordinadorFeatures.Common;
using BE_ProyectoA.Core.Domain.Entities.Votantes.VotantesDirigentesEntity;
using ErrorOr;
using MediatR;

namespace BE_ProyectoA.Core.Application.VotantesFeatures.VotantesDirigente.Queries.GetById
{
    internal class GetByIdVotantesDirigenteQueryHandler : IRequestHandler<GetByIdVotantesDirigenteQuery, ErrorOr<VotantesDirigenteReponse>>
    {
        private readonly IVotantesDirigenteRepository _votantesDirigenteRepository;

        public GetByIdVotantesDirigenteQueryHandler(IVotantesDirigenteRepository votantesDirigenteRepository)
        {
            _votantesDirigenteRepository = votantesDirigenteRepository;
        }

        public async Task<ErrorOr<VotantesDirigenteReponse>> Handle(GetByIdVotantesDirigenteQuery request, CancellationToken cancellationToken)
        {
            var votanteDirigente = await _votantesDirigenteRepository.GetByIdWithMembers(request.Id, cancellationToken);

            if (votanteDirigente == null)
            {

                return Error.NotFound("VotanteDirigente no encontrado");
            }

            var votanteResponseDTO = new VotantesDirigenteResponseDTO(
                votanteDirigente.VotanteId.Value,
                votanteDirigente.Votante.NombreCompleto,
                votanteDirigente.Votante.Cedula,
                votanteDirigente.Votante.NumeroTelefono,
                new DireccionVotantesDirigenteResponse(
                    votanteDirigente.Votante.Direccion.Provincia,
                    votanteDirigente.Votante.Direccion.Sector
                ),
                votanteDirigente.Votante.Activo,
                votanteDirigente.Dirigente != null ? new DirigenteResponse(votanteDirigente.Dirigente.Nombre,votanteDirigente.Dirigente.Apellido) : null
            );

            var votanteDirigenteResponse = new VotantesDirigenteReponse(votanteResponseDTO);

            return votanteDirigenteResponse;
        }
    }


}
