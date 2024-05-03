using BE_ProyectoA.Core.Application.VotantesFeatures.VotantesSubCoordinadorFeatures.Common;
using BE_ProyectoA.Core.Domain.Entities.Votantes.VotantesSubCoordinadores;
using ErrorOr;
using MediatR;

namespace BE_ProyectoA.Core.Application.VotantesFeatures.VotantesSubCoordinadorFeatures.Queries.GetByMemberId
{
    internal class GetByMemberIdVotantesSubCoordinadoQueryHandler : IRequestHandler<GetByMemberIdVotantesSubCoordinadorQuery, ErrorOr<IReadOnlyList<VotantesSubCoordinadorResponse>>>
    {
        private readonly IVotantesSubCoordiandoresRepository _repository;

        public GetByMemberIdVotantesSubCoordinadoQueryHandler(IVotantesSubCoordiandoresRepository repository)
        {
            _repository = repository;
        }

        public async Task<ErrorOr<IReadOnlyList<VotantesSubCoordinadorResponse>>> Handle(GetByMemberIdVotantesSubCoordinadorQuery request, CancellationToken cancellationToken)
        {
            var votanteSubCoordinador = await _repository.GetByMemberId(request.Id, cancellationToken);

            var response = votanteSubCoordinador.Select(
                           v => new VotantesSubCoordinadorResponse(
                               new VotantesSubCoordinadorResponseDTO(
                                   v.Votante.Id.Value,
                                   v.Votante.NombreCompleto,
                                   v.Votante.Cedula,
                                   v.Votante.NumeroTelefono,
                                   new DireccionVotantesSubCoordinadorResponse(
                                   v.Votante.Direccion.Provincia,
                                   v.Votante.Direccion.Sector),
                                   v.Votante.Activo,
                                   new SubCoordinadorResponse(v.SubCoordinador.NombreCompleto)

                           ))).ToList();


            return response;
        }
    }
}

