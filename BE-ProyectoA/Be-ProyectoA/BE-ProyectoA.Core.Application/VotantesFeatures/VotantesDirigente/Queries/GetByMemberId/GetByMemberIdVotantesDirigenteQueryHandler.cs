using BE_ProyectoA.Core.Application.VotantesFeatures.VotantesDirigente.Common;
using BE_ProyectoA.Core.Application.VotantesFeatures.VotantesSubCoordinadorFeatures.Common;
using BE_ProyectoA.Core.Domain.Entities.Votantes.VotantesDirigentesEntity;
using ErrorOr;
using MediatR;

namespace BE_ProyectoA.Core.Application.VotantesFeatures.VotantesDirigente.Queries.GetByMemberId
{
    internal class GetByMemberIdVotantesDirigenteQueryHandler : IRequestHandler<GetByMemberIdVotantesDirigenteQuery, ErrorOr<IReadOnlyList<VotantesDirigenteReponse>>>
    {
        private readonly IVotantesDirigenteRepository _repository;

        public GetByMemberIdVotantesDirigenteQueryHandler(IVotantesDirigenteRepository repository)
        {
            _repository = repository;
        }

        public async Task<ErrorOr<IReadOnlyList<VotantesDirigenteReponse>>> Handle(GetByMemberIdVotantesDirigenteQuery request, CancellationToken cancellationToken)
        {
            var votanteDiriegente = await _repository.GetByMemberId(request.Id, cancellationToken);

            var response = votanteDiriegente.Select(
                           v => new VotantesDirigenteReponse(
                               new VotantesDirigenteResponseDTO(
                                   v.Votante.Id.Value,
                                   v.Votante.NombreCompleto,
                                   v.Votante.Cedula,
                                   v.Votante.NumeroTelefono,
                                   new DireccionVotantesDirigenteResponse(
                                   v.Votante.Direccion.Provincia,
                                   v.Votante.Direccion.Sector),
                                   v.Votante.Activo,
                                   new DirigenteResponse(v.Dirigente.Nombre,v.Dirigente.Apellido)

                           ))).ToList();


            return response;
        }
    }
}
