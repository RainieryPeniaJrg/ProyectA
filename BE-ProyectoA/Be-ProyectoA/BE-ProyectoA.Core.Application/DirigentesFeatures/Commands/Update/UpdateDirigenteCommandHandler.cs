using BE_ProyectoA.Core.Application.Common.ValueObjectsValidators;
using BE_ProyectoA.Core.Domain.Entities.Coordinadores;
using BE_ProyectoA.Core.Domain.Entities.DirigenteMultiplicador;

using BE_ProyectoA.Core.Domain.Primitivies;
using BE_ProyectoA.Core.Domain.ValueObjects;
using ErrorOr;
using MediatR;


namespace BE_ProyectoA.Core.Application.DirigentesFeatures.Commands.Update
{
    public class UpdateDirigenteCommandHandler : IRequestHandler<UpdateDirigenteCommand, ErrorOr<Unit>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IDirigenteMultiplicadorRepository _dirigenteMultiplicadorRepository;
        private readonly ISubCoordinadorRepository _subCoordinadorRepository;

        public UpdateDirigenteCommandHandler(IUnitOfWork unitOfOfWork, IDirigenteMultiplicadorRepository dirigenteMultiplicadorRepository, ISubCoordinadorRepository subCoordinadorRepository)
        {
            _unitOfWork = unitOfOfWork;
            _dirigenteMultiplicadorRepository = dirigenteMultiplicadorRepository;
            _subCoordinadorRepository = subCoordinadorRepository;
        }

        public async Task<ErrorOr<Unit>> Handle(UpdateDirigenteCommand command, CancellationToken cancellationToken)
        {
            var id = new DirigentesMultiplicadoresId(command.Id);
            if(!await _dirigenteMultiplicadorRepository.ExistsAsync(command.Id, cancellationToken))
            {
                return Error.NotFound("Dirigente.NotFound", "El dirigente que selecciono no se encuentra, favor verificar campo");
            }
            if (!await _subCoordinadorRepository.ExistsAsync(command.SubCoordinadoresId, cancellationToken))
            {
                return Error.NotFound("EntidadRelacionada.NotFound", "La entidad relacionada no se encuentra, favor verificar campo");
            }
            var subCoordinador = await _subCoordinadorRepository.GetByIdAsync(command.SubCoordinadoresId, cancellationToken);

            var validationResult = ValueObjectValidators.ValidarDatos(command.Cedula, command.NumeroTelefono, command.Provincia, command.Sector, command.CasaElectoral);
            if (validationResult.IsError)
                return validationResult;

            var numeroTelefono = NumeroTelefono.Create(command.NumeroTelefono);

            var cedula = Cedula.Create(command.Cedula);

            var direccion = Direccion.Create(command.Provincia, command.Sector, command.CasaElectoral);
            var subId = new SubCoordinadoresId(command.SubCoordinadoresId);
           
            if (subCoordinador is not null && direccion is not null && cedula is not null && numeroTelefono is not null)
            {
                DirigentesMultiplicadores dirigentesMultiplicadores = DirigentesMultiplicadores.Update(id, cedula, numeroTelefono, command.Nombre, command.Apellido, command.Activo, direccion, command.CantidadVotantes, subCoordinador, subId);
                _dirigenteMultiplicadorRepository.Update(dirigentesMultiplicadores);
                await _unitOfWork.SaveChangesAsync(cancellationToken);
            }

            return Unit.Value;
        }
    }
}
