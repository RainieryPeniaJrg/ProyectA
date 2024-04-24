
using BE_ProyectoA.Core.Application.Common.ValueObjectsValidators;
using BE_ProyectoA.Core.Domain.Entities.CoordinadorGeneral;
using BE_ProyectoA.Core.Domain.Primitivies;
using BE_ProyectoA.Core.Domain.ValueObjects;
using ErrorOr;
using MediatR;


namespace BE_ProyectoA.Core.Application.CoordinadoresGeneralesFeatures.Commands.Create
{
    public class CreateCoordinadorGeneralCommandHandler : IRequestHandler<CreateCoordinadorCommand, ErrorOr<Unit>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ICoordinadorGeneralRepository _coordinadorGeneralRepository;

        public CreateCoordinadorGeneralCommandHandler(IUnitOfWork unitOfWork, ICoordinadorGeneralRepository coordinadorGeneralRepository)
        {
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
            _coordinadorGeneralRepository = coordinadorGeneralRepository ?? throw new ArgumentNullException(nameof(coordinadorGeneralRepository));  
        }

        public async Task<ErrorOr<Unit>> Handle(CreateCoordinadorCommand command, CancellationToken cancellationToken)
        {
            // Validar los datos de entrada
            var validationResult = ValueObjectValidators.ValidarDatos(command.Cedula,command.NumeroTelefono,command.Provincia,command.Sector,command.casaElectoral);
            if (validationResult.IsError)
                return validationResult;

   

            var numeroTelefono = NumeroTelefono.Create(command.NumeroTelefono);
            var cedula = Cedula.Create(command.Cedula);
            var direccion = Direccion.Create(command.Provincia, command.Sector, command.CantidadVotantes);

            var coordinador = new CoordinadoresGenerales
                (
                new CoordinadoresGeneralesId(Guid.NewGuid()),
                command.Nombre,
                command.Apellido,
                cedula,
                numeroTelefono,
                true,
                direccion,
                command.CantidadVotantes);
            // Guardar el votante y realizar cambios en la unidad de trabajo
            await _coordinadorGeneralRepository.AddAsync(coordinador, cancellationToken);
            await _unitOfWork.SaveChangesAsync(cancellationToken);

            return Unit.Value;


          
        }


        

        
    }
}
