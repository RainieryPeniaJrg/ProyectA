using BE_ProyectoA.Core.Application.Common.ValueObjectsValidators;
using BE_ProyectoA.Core.Domain.Entities.Coordinadores;
using BE_ProyectoA.Core.Domain.Entities.CoordinadorGeneral;
using BE_ProyectoA.Core.Domain.Primitivies;
using BE_ProyectoA.Core.Domain.ValueObjects;
using ErrorOr;
using MediatR;

namespace BE_ProyectoA.Core.Application.SubCoordinadorFeatures.Commands.Create
{
    public class CreateSubCoordinadorCommandHandler : IRequestHandler<CreateSubCoordinadorCommand, ErrorOr<Unit>>
    {

        private readonly IUnitOfWork _unitOfWork;
        private readonly ISubCoordinadorRepository _subCoordinadorRepository;
        private readonly ICoordinadorGeneralRepository _coordinadorGeneralRepository;

        public CreateSubCoordinadorCommandHandler(IUnitOfWork unitOfWork, ISubCoordinadorRepository subCoordinadorRepository, ICoordinadorGeneralRepository coordinadorGeneralRepository)
        {
            _unitOfWork = unitOfWork;
            _subCoordinadorRepository = subCoordinadorRepository;
            _coordinadorGeneralRepository = coordinadorGeneralRepository;
        }
        public async Task<ErrorOr<Unit>> Handle(CreateSubCoordinadorCommand command, CancellationToken cancellationToken)
        {
            var ipCoordinadorGeneral = new CoordinadoresGeneralesId(command.CoordinadorsGeneralesId);
            // Validar los datos de entrada
            var validationResult = ValueObjectValidators.ValidarDatos(command.Cedula, command.NumeroTelefono, command.Provincia, command.Sector, command.CasaElectoral);
            if (validationResult.IsError)
                return validationResult;

            if (!await _coordinadorGeneralRepository.ExistsAsync(ipCoordinadorGeneral, cancellationToken))
            {
                return Error.Validation("SubCoordinadores.NotFound", "El SubCoordinadores proporcionador no se encuentra");
            }

            var coordinadorGeneral = await _coordinadorGeneralRepository.GetByIdAsync(ipCoordinadorGeneral, cancellationToken);

            var numeroTelefono = NumeroTelefono.Create(command.NumeroTelefono);

            var cedula = Cedula.Create(command.Cedula);

            var direccion = Direccion.Create(command.Provincia, command.Sector, command.CasaElectoral);

            if(coordinadorGeneral is not null && numeroTelefono is not null && cedula is not null && direccion is not null)
            {
                var subCoordinador = new SubCoordinadores(
                    new SubCoordinadoresId(Guid.NewGuid()),
                    command.Nombre,command.Apellido,CantidadVotos.Create(command.CantidadVotos),
                    numeroTelefono,cedula,command.Activo,direccion,coordinadorGeneral);

               await _subCoordinadorRepository.AddAsync(subCoordinador,cancellationToken);
               await _unitOfWork.SaveChangesAsync(cancellationToken);
            }
            return Unit.Value;
           
        }
    }
}

