using BE_ProyectoA.Core.Application.Common.ValueObjectsValidators;
using BE_ProyectoA.Core.Domain.Entities.Coordinadores;
using BE_ProyectoA.Core.Domain.Entities.CoordinadorGeneral;
using BE_ProyectoA.Core.Domain.Entities.DirigenteMultiplicador;
using BE_ProyectoA.Core.Domain.Primitivies;
using BE_ProyectoA.Core.Domain.ValueObjects;
using ErrorOr;
using MediatR;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace BE_ProyectoA.Core.Application.SubCoordinadorFeatures.Commands.Update
{
    public class UpdateSubCoordinadorCoomandHandler : IRequestHandler<UpdateSubCoordinadorCommand, ErrorOr<Unit>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ISubCoordinadorRepository _subCoordinadorRepository;
        private readonly ICoordinadorGeneralRepository _coordinadorGeneralRepository;

        public UpdateSubCoordinadorCoomandHandler(IUnitOfWork unitOfWork, ISubCoordinadorRepository subCoordinadorRepository, ICoordinadorGeneralRepository coordinadorGeneralRepository)
        {
            _unitOfWork = unitOfWork;
            _subCoordinadorRepository = subCoordinadorRepository;
            _coordinadorGeneralRepository = coordinadorGeneralRepository;
        }

        public async Task<ErrorOr<Unit>> Handle(UpdateSubCoordinadorCommand command, CancellationToken cancellationToken)
        {
            var id = new SubCoordinadoresId(command.Id);
            var coordinadorGeneralId = new CoordinadoresGeneralesId(command.CoordinadorsGeneralesId);

            if (!await _coordinadorGeneralRepository.ExistsAsync(coordinadorGeneralId, cancellationToken))
            {
                return Error.NotFound("CoordinadorGeneral.NotFound", "El coordinador general que seleccionó no se encuentra. Favor verificar el campo.");
            }

            var coordinadorGeneral = await _coordinadorGeneralRepository.GetByIdAsync2(coordinadorGeneralId, cancellationToken);

            if (coordinadorGeneral == null)
            {
                return Error.NotFound("CoordinadorGeneral.NotFound", "El coordinador general que seleccionó no se encuentra. Favor verificar el campo.");
            }

            var coordinador = await _subCoordinadorRepository.GetByIdAsync(id, cancellationToken);

            if (coordinador == null)
            {
                // Manejar el caso en el que no se pueda encontrar el dirigente
                return Error.NotFound("Coordinador.NotFound", "El coordinador que seleccionó no se encuentra. Favor verificar el campo.");
            }

            var validationResult = ValueObjectValidators.ValidarDatos(command.Cedula, command.NumeroTelefono, command.Provincia, command.Sector, command.CasaElectoral);
            if (validationResult.IsError)
            {
                return validationResult;
            }

            var numeroTelefono = NumeroTelefono.Create(command.NumeroTelefono);
            var cedula = Cedula.Create(command.Cedula);
            var direccion = Direccion.Create(command.Provincia, command.Sector, command.CasaElectoral);

            if (direccion is not null && cedula is not null && numeroTelefono is not null)
            {
                SubCoordinadores subCoordinador = SubCoordinadores.Update(
                    id,
                    command.Nombre,
                    command.Apellido,
                    CantidadVotos.Create(command.CantidadVotantes),
                    numeroTelefono,
                    cedula,
                    command.Activo,
                    direccion,
                    coordinadorGeneral.Id,
                    coordinadorGeneral
                );

                _subCoordinadorRepository.Update2(subCoordinador);
                await _unitOfWork.SaveChangesAsync(cancellationToken);
            }

            return Unit.Value;
        }
    }
}
