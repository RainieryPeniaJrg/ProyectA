using BE_ProyectoA.Core.Application.VotantesFeatures.VotantesDirector.Common;
using BE_ProyectoA.Core.Application.VotantesFeatures.VotantesDirigente.Common;
using BE_ProyectoA.Core.Domain.Entities.Votantes.VotantesDirector;
using BE_ProyectoA.Core.Domain.Entities.Votantes.VotantesDirigentesEntity;
using ErrorOr;
using MediatR;

namespace BE_ProyectoA.Core.Application.VotantesFeatures.VotantesDirector.Queries.GetById
{
    internal class GetByIdVotantesDirectorQueryHandler : IRequestHandler<GetByIdVotantesDirectorQuery, ErrorOr<VotantesDirectorResponse>>
    {
        private readonly IVotantesDirectorRepository _repository;

        public GetByIdVotantesDirectorQueryHandler(IVotantesDirectorRepository repository)
        {
            _repository = repository;
        }

        public async Task<ErrorOr<VotantesDirectorResponse>> Handle(GetByIdVotantesDirectorQuery request, CancellationToken cancellationToken)
        {
            var votante = await _repository.GetByIdWithMembers(request.Id, cancellationToken);

            if (votante == null)
            {

                return Error.NotFound("VotanteDirigente no encontrado");
            }

            var votanteResponseDTO = new VotantesDirectorResponseDTO(
                votante.VotanteId.Value,
                votante.Votante.NombreCompleto,
                votante.Votante.Cedula,
                votante.Votante.NumeroTelefono,
                new DireccionVotantesDirectorResponse(
                    votante.Votante.Direccion.Provincia,
                    votante.Votante.Direccion.Sector
                ),
                votante.Votante.Activo,
                votante.Director != null ? new DirectorResponse(votante.Director.NombreCompleto) : null
            );

            var votanteDirigenteResponse = new VotantesDirectorResponse(votanteResponseDTO);

            return votanteDirigenteResponse;
        }
    }
}
