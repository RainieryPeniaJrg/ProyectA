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
            var dirigentes = new List<DirigentesMultiplicadores>();
            var subCoordinadores = new List<SubCoordinadores>();

            foreach (var dirigenteId in command.DirigentesMultiplicadoresIds)
            {
                var dirigente = await _dirigenteMultiplicadorRepository.GetByIdAsync(new DirigentesMultiplicadoresId(dirigenteId), cancellationToken);
                if (dirigente != null)
                {
                    dirigentes.Add(dirigente);
                }
            }

            var coordinador = await _coordinadorGeneralRepository.GetByIdAsync(new CoordinadoresGeneralesId(command.CoordinadoresGeneralesId), cancellationToken);

            foreach (var subCoordinadorId in command.SubCoordinadoresIds)
            {
                var subCoordinador = await _subCoordinadorRepository.GetByIdAsync(new SubCoordinadoresId(subCoordinadorId), cancellationToken);
                if (subCoordinador != null)
                {
                    subCoordinadores.Add(subCoordinador);
                }
            }

            var grupo = new Grupos(
                command.NombreGrupo,
                new GruposId(Guid.NewGuid()),
                dirigentes.Any() ? dirigentes : null, // Inicializa la colección solo si contiene elementos
                coordinador,
                subCoordinadores.Any() ? subCoordinadores : null, // Inicializa la colección solo si contiene elementos
                command.Active
            );
            await _gruposRepository.AddAsync(grupo, cancellationToken);
            await _unitOfWork.SaveChangesAsync(cancellationToken);



            return Unit.Value;
        }
    }
}
