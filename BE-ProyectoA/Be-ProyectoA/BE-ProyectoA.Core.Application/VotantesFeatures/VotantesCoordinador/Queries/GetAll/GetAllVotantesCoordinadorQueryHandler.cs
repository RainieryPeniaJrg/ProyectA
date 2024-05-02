using BE_ProyectoA.Core.Application.VotantesFeatures.VotantesCoordinador.Common;
using BE_ProyectoA.Core.Domain.Entities.Votantes.VotantesCoordinadorGeneral;
using ErrorOr;
using MediatR;

namespace BE_ProyectoA.Core.Application.VotantesFeatures.VotantesCoordinador.Queries.GetAll
{
    internal class GetAllVotantesCoordinadorQueryHandler : IRequestHandler<GetAllVotantesCoordinadorQuery, ErrorOr<IReadOnlyList<VotantesCoordinadorResponse>>>
    {
        private readonly IVotanteCoordinadorRepository _votanteCoordinadorRepository;

        public GetAllVotantesCoordinadorQueryHandler(IVotanteCoordinadorRepository votanteCoordinadorRepository)
        {
            _votanteCoordinadorRepository = votanteCoordinadorRepository;
        }

        public async Task<ErrorOr<IReadOnlyList<VotantesCoordinadorResponse>>> Handle(GetAllVotantesCoordinadorQuery request, CancellationToken cancellationToken)
        {
            var votantes = await _votanteCoordinadorRepository.GetAllVotantesCoordinador(cancellationToken);


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
