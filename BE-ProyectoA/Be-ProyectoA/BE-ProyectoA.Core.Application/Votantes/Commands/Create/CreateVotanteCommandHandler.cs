using BE_ProyectoA.Core.Application.Director.Commands.Create;
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
        private readonly IVotantesRepository _votantesRepository;

        public CreateVotanteCommandHandler(IUnitOfWork unitOfWork, IVotantesRepository votantesRepository)
        {
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
            _votantesRepository = votantesRepository ?? throw new ArgumentNullException(nameof(votantesRepository));
        }

        public async Task<ErrorOr<Unit>> Handle(CreateVotanteCommand command, CancellationToken cancellationToken)
        {
        

            if (NumeroTelefono.Create(command.NumeroTelefono) is not NumeroTelefono numeroTelefono)
            {
                return Error.Validation("Votantes.NumeroTelefono", "El numero de telefono no esta en un formato valido");
            }

            if (Cedula.Create(command.Cedula) is not Cedula cedula)
            {
                return Error.Validation("Votantes.Cedula", "La Cedula no es valida");

            }

            if (Direccion.Create(command.Provincia,command.Sector) is not Direccion direccion)
            {
                return Error.Validation("Votantes.Direccion", "La Direccion no es valida");

            }

            var votante = new Votante
                (
                 new VotanteId(Guid.NewGuid()),
                command.Nombre,
                command.Apellido,
             
                cedula,
                direccion,
                numeroTelefono,
                true
                
                );

             _votantesRepository.Add(votante);
            await _unitOfWork.SaveChangesAsync(cancellationToken);
           
            return Unit.Value;
        }
    }
}
