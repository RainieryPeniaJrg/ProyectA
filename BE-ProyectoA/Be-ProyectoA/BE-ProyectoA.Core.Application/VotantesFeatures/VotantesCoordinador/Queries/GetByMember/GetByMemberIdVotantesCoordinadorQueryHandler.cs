using BE_ProyectoA.Core.Application.VotantesFeatures.VotantesCoordinador.Common;
using BE_ProyectoA.Core.Domain.Entities.Votantes.VotantesCoordinadorGeneral;
using ErrorOr;
using MediatR;

namespace BE_ProyectoA.Core.Application.VotantesFeatures.VotantesCoordinador.Queries.GetByMember
{
    internal class GetByMemberIdVotantesCoordinadorQueryHandler : IRequestHandler<GetByMemberIdVotantesCoordinadorQuery, ErrorOr<IReadOnlyList<VotantesCoordinadorResponse>>>
    {
        private readonly IVotanteCoordinadorRepository _repository;

        public GetByMemberIdVotantesCoordinadorQueryHandler(IVotanteCoordinadorRepository repository)
        {
            _repository = repository;
        }

        public async Task<ErrorOr<IReadOnlyList<VotantesCoordinadorResponse>>> Handle(GetByMemberIdVotantesCoordinadorQuery request, CancellationToken cancellationToken)
        {
            var votantes = await _repository.GetByMemberId(request.Id,cancellationToken);

            var response = votantes.Select(
                 v => new VotantesCoordinadorResponse(
                     new VotantesResponse(
                         v.Votante.Id.Value,
                     v.Votante.NombreCompleto,
                     v.Votante.Cedula,
                     v.Votante.NumeroTelefono,
                     new DireccionResponse(v.Votante.Direccion.Provincia,
                     v.Votante.Direccion.Sector),
                     v.Votante.Activo,
                     new CoordinadorGeneralResponse(
                         v.Coordinador.Nombre,
                     v.Coordinador.Apellido)

                 ))).ToList();

            return response;
        }
    }
}
