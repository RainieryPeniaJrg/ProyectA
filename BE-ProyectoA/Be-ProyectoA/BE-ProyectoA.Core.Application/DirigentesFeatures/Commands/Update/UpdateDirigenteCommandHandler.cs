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

            if (!await _subCoordinadorRepository.ExistsAsync(new SubCoordinadoresId(command.SubCoordinadoresId), cancellationToken))
            {
                return Error.NotFound("EntidadRelacionada.NotFound", "La entidad relacionada no se encuentra. Favor verificar el campo.");
            }

            var dirigente = await _dirigenteMultiplicadorRepository.GetByIdAsync(id, cancellationToken);

            if (dirigente == null)
            {
                // Manejar el caso en el que no se pueda encontrar el dirigente
                return Error.NotFound("Dirigente.NotFound", "El dirigente que seleccionó no se encuentra. Favor verificar el campo.");
            }

            var subCoordinador = await _subCoordinadorRepository.GetByIdAsync2(new SubCoordinadoresId(command.SubCoordinadoresId), cancellationToken);

            var validationResult = ValueObjectValidators.ValidarDatos(command.Cedula, command.NumeroTelefono, command.Provincia, command.Sector, command.CasaElectoral);
            if (validationResult.IsError)
            {
                return validationResult;
            }

            var numeroTelefono = NumeroTelefono.Create(command.NumeroTelefono);
            var cedula = Cedula.Create(command.Cedula);
            var direccion = Direccion.Create(command.Provincia, command.Sector, command.CasaElectoral);

            if (subCoordinador is not null && direccion is not null && cedula is not null && numeroTelefono is not null)
            {
                
       
                // Actualizamos los datos del dirigente multiplicador con los nuevos datos proporcionados
                var dirigenteMultiplicador = DirigentesMultiplicadores.Update(
                     id,
                    cedula,
                    numeroTelefono,
                    command.Nombre,
                    command.Apellido,
                    command.Activo,
                    direccion,
                    CantidadVotos.Create(command.CantidadVotantes),
                    subCoordinador,
                    new SubCoordinadoresId(command.SubCoordinadoresId)


                );

                // Utilizamos el método Update del repositorio para actualizar el dirigente multiplicador
                _dirigenteMultiplicadorRepository.Update2(dirigenteMultiplicador);

                // Guardamos los cambios en la base de datos
                await _unitOfWork.SaveChangesAsync(cancellationToken);
            }

            return Unit.Value;
        }

       
    }


}
