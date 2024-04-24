using BE_ProyectoA.Core.Domain.Entities.Coordinadores;
using BE_ProyectoA.Core.Domain.Entities.CoordinadorGeneral;
using BE_ProyectoA.Core.Domain.Entities.DirigenteMultiplicador;
using BE_ProyectoA.Core.Domain.Entities.GruposEntity;
using BE_ProyectoA.Core.Domain.Primitivies;
using ErrorOr;
using MediatR;

namespace BE_ProyectoA.Core.Application.GrupoFeatures.Commands.Create
{
    public class CreateGruposCommandHandler : IRequestHandler<CreateGruposCommand, ErrorOr<Unit>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IGruposRepository _gruposRepository;
        private readonly IDirigenteMultiplicadorRepository _dirigenteMultiplicadorRepository;
        private readonly ISubCoordinadorRepository _subCoordinadorRepository;
        private readonly ICoordinadorGeneralRepository _coordinadorGeneralRepository;

        public CreateGruposCommandHandler(IUnitOfWork unitOfWork, IGruposRepository gruposRepository, IDirigenteMultiplicadorRepository dirigenteMultiplicadorRepository, ISubCoordinadorRepository subCoordinadorRepository, ICoordinadorGeneralRepository coordinadorGeneralRepository)
        {
            _unitOfWork = unitOfWork;
            _gruposRepository = gruposRepository;
            _dirigenteMultiplicadorRepository = dirigenteMultiplicadorRepository;
            _subCoordinadorRepository = subCoordinadorRepository;
            _coordinadorGeneralRepository = coordinadorGeneralRepository;
        }

        public async Task<ErrorOr<Unit>> Handle(CreateGruposCommand command, CancellationToken cancellationToken)
        {
            var ipDirigente = new DirigentesMultiplicadoresId(command.DirigentesMultiplicadoresId);
            var ipSubCoordinador = new SubCoordinadoresId(command.SubCoordinadoresId);
            var ipCoordinadorGeneral = new CoordinadoresGeneralesId(command.CoordinadoresGeneralesId);

            if (!await _subCoordinadorRepository.ExistsAsync(ipSubCoordinador, cancellationToken))
            {
                return Error.Validation("SubCoordinadores.NotFound", "El SubCoordinador proporcionado no se encuentra");
            }

            if (!await _dirigenteMultiplicadorRepository.ExistsAsync(ipDirigente, cancellationToken))
            {
                return Error.Validation("Dirigente.NotFound", "El Dirigente proporcionado no se encuentra");
            }

            if (!await _coordinadorGeneralRepository.ExistsAsync(ipCoordinadorGeneral, cancellationToken))
            {
                return Error.Validation("Coordinador.NotFound", "El Coordinador proporcionado no se encuentra");
            }

            var subCoordinador = await _subCoordinadorRepository.GetByIdAsync(ipSubCoordinador, cancellationToken);

            var dirigente = await _dirigenteMultiplicadorRepository.GetByIdAsync(ipDirigente, cancellationToken);

            var coordinadorGeneral = await _coordinadorGeneralRepository.GetByIdAsync(ipCoordinadorGeneral, cancellationToken);

            if(subCoordinador is not null && dirigente is not null && coordinadorGeneral is not null)
            {
                var Grupo = new Grupos(command.NombreGrupo, new GruposId(Guid.NewGuid()), dirigente, coordinadorGeneral, subCoordinador, command.Active);
                await _gruposRepository.AddAsync(Grupo,cancellationToken);
                await _unitOfWork.SaveChangesAsync(cancellationToken);
            }

            return Unit.Value;
        }
    }
}
