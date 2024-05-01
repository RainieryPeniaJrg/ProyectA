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
            if(!await _subCoordinadorRepository.ExistsAsync(command.Id, cancellationToken))
            {
                return Error.NotFound("SubCoordinador.NotFound", "El dirigente que selecciono no se encuentra, favor verificar campo");
            }
            if(!await _coordinadorGeneralRepository.ExistsAsync(command.CoordinadorsGeneralesId, cancellationToken))
            {
                return Error.NotFound("CoordinadorGeneral.NotFound", "El dirigente que selecciono no se encuentra, favor verificar campo");
            }

            var CoordinadorGeneral = await _coordinadorGeneralRepository.GetByIdAsync(command.CoordinadorsGeneralesId, cancellationToken);

            var validationResult = ValueObjectValidators.ValidarDatos(command.Cedula, command.NumeroTelefono, command.Provincia, command.Sector, command.CasaElectoral);
            if (validationResult.IsError)
                return validationResult;

            var numeroTelefono = NumeroTelefono.Create(command.NumeroTelefono);

            var cedula = Cedula.Create(command.Cedula);

            var direccion = Direccion.Create(command.Provincia, command.Sector, command.CasaElectoral);

            if (CoordinadorGeneral is not null && direccion is not null && cedula is not null && numeroTelefono is not null)
            {   
                SubCoordinadores subCoordinador = SubCoordinadores.Update(id, command.Nombre,command.Apellido,command.CantidadVotantes,numeroTelefono,cedula,command.Activo,direccion,CoordinadorGeneral.Id ,CoordinadorGeneral);
                _subCoordinadorRepository.Update(subCoordinador);
                await _unitOfWork.SaveChangesAsync(cancellationToken);
            }

            return Unit.Value;
            throw new NotImplementedException();
        }
    }
}
