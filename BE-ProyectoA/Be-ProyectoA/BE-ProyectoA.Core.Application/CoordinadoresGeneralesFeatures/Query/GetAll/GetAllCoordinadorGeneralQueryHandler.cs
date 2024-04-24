using BE_ProyectoA.Core.Application.CoordinadoresGeneralesFeatures.Common;
using BE_ProyectoA.Core.Application.Votantes.Commons;
using BE_ProyectoA.Core.Domain.Entities.CoordinadorGeneral;
using BE_ProyectoA.Core.Domain.Entities.Votantes;
using BE_ProyectoA.Core.Domain.Primitivies;
using BE_ProyectoA.Core.Domain.ValueObjects;
using ErrorOr;
using MediatR;

namespace BE_ProyectoA.Core.Application.CoordinadoresGeneralesFeatures.Query.GetAll
{
    public class GetAllCoordinadorGeneralQueryHandler : IRequestHandler<GetAllCoordinadorGeneralQuery, ErrorOr<IReadOnlyList<CoordinadorGeneralResponse>>>
    {

        private readonly ICoordinadorGeneralRepository _coordinadorGeneralRepository;

        public GetAllCoordinadorGeneralQueryHandler(ICoordinadorGeneralRepository coordinadorGeneralRepository)
        {

            _coordinadorGeneralRepository = coordinadorGeneralRepository;
        }

        public async Task<ErrorOr<IReadOnlyList<CoordinadorGeneralResponse>>> Handle(GetAllCoordinadorGeneralQuery Query, CancellationToken cancellationToken)
        {
            IReadOnlyList<CoordinadoresGenerales> coordinadoresGenerales = await _coordinadorGeneralRepository.GetAll(cancellationToken);

            return coordinadoresGenerales.Select
                (
                c => new
                CoordinadorGeneralResponse(c.Id.Value, c.Nombre, c.CantidadVotantes, c.Cedula, c.NumeroTelefono, new DireccionResponseCoordinador(c.Direccion.Provincia, c.Direccion.Sector, c.Direccion.CasaElectoral), c.Activo)
                ).ToList();

        }

    }
 }
 
