using BE_ProyectoA.Core.Application.DirigentesFeatures.Querys.GetAll;
using BE_ProyectoA.Core.Application.VotantesFeatures.VotantesCoordinador.Common;
using BE_ProyectoA.Core.Application.VotantesFeatures.VotantesDirector.Queries.GetAll;
using BE_ProyectoA.Core.Application.VotantesFeatures.VotantesDirigente.Common;
using BE_ProyectoA.Core.Domain.Entities.Votantes.VotantesCoordinadorGeneral;
using BE_ProyectoA.Core.Domain.Entities.Votantes.VotantesDirigentesEntity;
using ErrorOr;
using MediatR;

namespace BE_ProyectoA.Core.Application.VotantesFeatures.VotantesDirigente.Queries.GetAll
{
    internal class GetAllVotantesDirigenteQueryHandler : IRequestHandler<GetAllVotantesDirigenteQuery, ErrorOr<IReadOnlyList<VotantesDirigenteReponse>>>
    {
        private readonly IVotantesDirigenteRepository _repository;

        public GetAllVotantesDirigenteQueryHandler(IVotantesDirigenteRepository repository)
        {
            _repository = repository;
        }

        public async Task<ErrorOr<IReadOnlyList<VotantesDirigenteReponse>>> Handle(GetAllVotantesDirigenteQuery request, CancellationToken cancellationToken)
        {
            var votantes = await _repository.GetAllVotantesDirigente(cancellationToken);


            var response = votantes.Select(
                v => new VotantesDirigenteReponse(
                    new VotantesDirigenteResponseDTO(
                        v.Votante.Id.Value,
                    v.Votante.NombreCompleto,
                    v.Votante.Cedula,
                    v.Votante.NumeroTelefono,
                    new DireccionVotantesDirigenteResponse(v.Votante.Direccion.Provincia,
                    v.Votante.Direccion.Sector),
                    v.Votante.Activo,
                    new DirigenteResponse(
                        v.Dirigente.Nombre,
                    v.Dirigente.Apellido)

                ))).ToList();

            return response;
        }
    }
}
