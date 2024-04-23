using BE_ProyectoA.Core.Application.Common.ValueObjectsValidators;
using BE_ProyectoA.Core.Domain.Entities.Votantes;
using BE_ProyectoA.Core.Domain.Primitivies;
using BE_ProyectoA.Core.Domain.ValueObjects;
using ErrorOr;
using MediatR;

namespace BE_ProyectoA.Core.Application.Votantes.Commands.Create
{
    public class CreateVotanteCommandHandler : IRequestHandler<CreateVotanteCommand, ErrorOr<Unit>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IVotanteRepository _votantesRepository;

        public CreateVotanteCommandHandler(IUnitOfWork unitOfWork, IVotanteRepository votantesRepository)
        {
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
            _votantesRepository = votantesRepository ?? throw new ArgumentNullException(nameof(votantesRepository));
        }

        public async Task<ErrorOr<Unit>> Handle(CreateVotanteCommand command, CancellationToken cancellationToken)
        {
          
            // Validar los datos de entrada
            var validationResult = ValueObjectValidators.ValidarDatos(command.Cedula, command.NumeroTelefono, command.Provincia, command.Sector);
            if (validationResult.IsError)
                return validationResult;

            var numeroTelefono = NumeroTelefono.Create(command.NumeroTelefono);
            var cedula = Cedula.Create(command.Cedula);
            var direccion = Direccion.Create(command.Provincia, command.Sector);
            // Crear el votante

            var votante = new Votante(
                new VotanteId(Guid.NewGuid()),
                command.Nombre,
                command.Apellido,
                cedula,
                direccion,
                numeroTelefono,
                true
            );

            // Guardar el votante y realizar cambios en la unidad de trabajo
            await _votantesRepository.AddAsync(votante, cancellationToken);
            await _unitOfWork.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }

       

      
    }
}
