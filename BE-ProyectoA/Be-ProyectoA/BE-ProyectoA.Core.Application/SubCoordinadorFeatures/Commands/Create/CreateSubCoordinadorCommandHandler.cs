using BE_ProyectoA.Core.Application.Common.ValueObjectsValidators;
using BE_ProyectoA.Core.Domain.Entities.Coordinadores;
using BE_ProyectoA.Core.Domain.Entities.CoordinadorGeneral;
using BE_ProyectoA.Core.Domain.Primitivies;
using BE_ProyectoA.Core.Domain.ValueObjects;
using ErrorOr;
using MediatR;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace BE_ProyectoA.Core.Application.SubCoordinadorFeatures.Commands.Create
{
    public class CreateSubCoordinadorCommandHandler : IRequestHandler<CreateSubCoordinadorCommand, ErrorOr<Unit>>
    {

        private readonly ISubCoordinadorRepository _subCoordinadorRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly ICoordinadorGeneralRepository _coordinadorGeneralRepository;

        public CreateSubCoordinadorCommandHandler(ISubCoordinadorRepository subCoordinadorRepository, IUnitOfWork unitOfWork, ICoordinadorGeneralRepository coordinadorGeneralRepository)
        {
            _subCoordinadorRepository = subCoordinadorRepository;
            _unitOfWork = unitOfWork;
            _coordinadorGeneralRepository = coordinadorGeneralRepository;
        }

        public async Task<ErrorOr<Unit>> Handle(CreateSubCoordinadorCommand command, CancellationToken cancellationToken)
        {
            var validationResult = ValueObjectValidators.ValidarDatos(command.Cedula, command.NumeroTelefono, command.Provincia, command.Sector, command.CasaElectoral);
            if (validationResult.IsError)
                return validationResult;

            var numeroTelefono = NumeroTelefono.Create(command.NumeroTelefono);
            var cedula = Cedula.Create(command.Cedula);
            var direccion = Direccion.Create(command.Provincia, command.Sector, command.CasaElectoral);

            var IpCoordinadorGeneralId = new CoordinadoresGeneralesId(command.CoordinadorGeneralId);

            if (!await _coordinadorGeneralRepository.ExistsAsync(IpCoordinadorGeneralId, cancellationToken))
            {
                return Error.Validation("SubCoordinadores.NotFound", "El SubCoordinadores proporcionador no se encuentra");
            }
            var coordinadorGeneral = await _coordinadorGeneralRepository.GetByIdAsync(IpCoordinadorGeneralId, cancellationToken);

            if (coordinadorGeneral != null)
            {
                var SubCoordinador = new SubCoordinadores(new SubCoordinadoresId(Guid.NewGuid()),
                        command.Nombre, command.Apellido, command.CantidadVotantes,
                        numeroTelefono, cedula, command.Activo, direccion,
                        coordinadorGeneral);

                await _subCoordinadorRepository.AddAsync(SubCoordinador, cancellationToken);
                await _unitOfWork.SaveChangesAsync(cancellationToken);
            }


            return Unit.Value;




        }
    }
}