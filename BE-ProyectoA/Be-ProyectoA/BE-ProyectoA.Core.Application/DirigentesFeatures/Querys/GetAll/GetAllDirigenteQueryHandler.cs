using BE_ProyectoA.Core.Application.DirigentesFeatures.Commom;
using BE_ProyectoA.Core.Application.SubCoordinadorFeatures.Common;
using BE_ProyectoA.Core.Domain.Entities.Coordinadores;
using BE_ProyectoA.Core.Domain.Entities.DirigenteMultiplicador;
using ErrorOr;
using MediatR;

namespace BE_ProyectoA.Core.Application.DirigentesFeatures.Querys.GetAll
{


    public class GetAllDirigenteQueryHandler : IRequestHandler<GetAllDirigenteQuery, ErrorOr<IReadOnlyList<DirigenteResponse>>>
    {
        private readonly IDirigenteMultiplicadorRepository _dirigenteMultiplicadorRepository;
        private readonly ISubCoordinadorRepository _subCoordinadorRepostory;

        public GetAllDirigenteQueryHandler(IDirigenteMultiplicadorRepository dirigenteMultiplicadorRepository, ISubCoordinadorRepository subCoordinadorRepository)
        {
            _dirigenteMultiplicadorRepository = dirigenteMultiplicadorRepository;
            _subCoordinadorRepostory = subCoordinadorRepository;
        }

        public async Task<ErrorOr<IReadOnlyList<DirigenteResponse>>> Handle(GetAllDirigenteQuery query, CancellationToken cancellationToken)
        {
            var dirigenteMultiplicadores = await _dirigenteMultiplicadorRepository.GetAllDirigenteMultiplicadores(cancellationToken);

            var dirigenteResponses = dirigenteMultiplicadores.Select(
                dm => new DirigenteResponse(dm.Id.Value, dm.NombreCompleto,
                dm.CantidadVotantes, dm.Cedula, dm.NumeroTelefono,
                new DireccionResponseDirigente(dm.Direccion.Provincia,
                dm.Direccion.Sector, dm.Direccion.CasaElectoral),
                new CoordinadorResponse
                (dm.SubCoordinadores.Id.Value, dm.SubCoordinadores.NombreCompleto,
                dm.SubCoordinadores.CantidadVotantes, dm.SubCoordinadores.Cedula,
                dm.SubCoordinadores.NumeroTelefono, dm.SubCoordinadores.Activo),
                dm.Activo)
                {

                }).ToList();

            return dirigenteResponses;
        }
    }
    }

