using BE_ProyectoA.Core.Application.SubCoordinadorFeatures.Common;
using BE_ProyectoA.Core.Domain.Entities.Coordinadores;
using ErrorOr;
using MediatR;

namespace BE_ProyectoA.Core.Application.SubCoordinadorFeatures.Querys
{
    public class GetAllSubCoordinadorQueryHandler : IRequestHandler<GetAllSubCoordinadorQuery, ErrorOr<IReadOnlyList<SubCoordinadorResponse>>>
    {
        private readonly ISubCoordinadorRepository _subCoordinadorRepository;

        public GetAllSubCoordinadorQueryHandler(ISubCoordinadorRepository subCoordinadorRepository)
        {
            _subCoordinadorRepository = subCoordinadorRepository;
        }

        public async Task<ErrorOr<IReadOnlyList<SubCoordinadorResponse>>> Handle(GetAllSubCoordinadorQuery request, CancellationToken cancellationToken)
        {
            var subCoordinadores = await _subCoordinadorRepository.GetAllSubCoordinadores(cancellationToken);

            var subCoordindoresRespose = subCoordinadores.Select(
                sc => new SubCoordinadorResponse (sc.Id.Value,sc.Nombre,sc.CantidadVotantes,sc.Cedula,sc.NumeroTelefono,
                new DireccionResponseCoordinador(sc.Direccion.Provincia,sc.Direccion.Sector,
                sc.Direccion.CasaElectoral),new GerenteGeneralResponsse(sc.CoordinadorsGeneralesId.Value,sc.Coordinadores.NombreCompleto,
                sc.Coordinadores.CantidadVotantes,sc.Coordinadores.Cedula,
                sc.Coordinadores.NumeroTelefono,
                sc.Coordinadores.Activo),sc.Activo)

                ).ToList();

            return subCoordindoresRespose;
        }
    }
}
