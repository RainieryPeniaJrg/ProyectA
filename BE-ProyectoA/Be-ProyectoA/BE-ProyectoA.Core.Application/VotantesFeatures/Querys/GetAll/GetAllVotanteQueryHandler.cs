using BE_ProyectoA.Core.Application.VotantesFeatures.Commons;
using BE_ProyectoA.Core.Domain.Entities.Votantes;
using BE_ProyectoA.Core.Domain.Entities.Votantes.VotantesCoordinadorGeneral;
using ErrorOr;
using MediatR;
using System.Linq;

namespace BE_ProyectoA.Core.Application.VotantesFeatures.Querys.GetAll
{
    public class GetAllVotanteQueryHandler : IRequestHandler<GetAllVotanteQuery, ErrorOr<IReadOnlyList<VotantesResponse>>>
    {
        private readonly IVotanteRepository _votanteRepository;
        private readonly IVotanteCoordinadorRepository _votanteCoordinadorRepository;

        public GetAllVotanteQueryHandler(IVotanteRepository votanteRepository, IVotanteCoordinadorRepository votanteCoordinadorRepository)
        {
            _votanteRepository = votanteRepository ?? throw new ArgumentNullException(nameof(votanteRepository));
            _votanteCoordinadorRepository = votanteCoordinadorRepository;
        }
        public async Task<ErrorOr<IReadOnlyList<VotantesResponse>>> Handle(GetAllVotanteQuery query, CancellationToken cancellationToken)
        {
            var votantes = await _votanteRepository.GetAllWithMembers(cancellationToken);
            var votantesCoordinadorList = await _votanteCoordinadorRepository.GetAllVotantesCoordinador(cancellationToken);

            var votantesResponse = votantes.Select(user =>
            {
                var coordinadores = votantesCoordinadorList
                    .Where(vc => vc.VotanteId == user.Id)
                    .Select(vc => vc.CoordinadorId)
                    .ToList();

                return new VotantesResponse(
                    user.Id.Value,
                    user.NombreCompleto,
                    user.Cedula,
                    user.NumeroTelefono,
                    new DireccionResponse(user.Direccion.Provincia, user.Direccion.Sector),
                    user.Activo,
                    coordinadores
                );
            }).ToList();

            return votantesResponse.AsReadOnly();
        }
    }
}