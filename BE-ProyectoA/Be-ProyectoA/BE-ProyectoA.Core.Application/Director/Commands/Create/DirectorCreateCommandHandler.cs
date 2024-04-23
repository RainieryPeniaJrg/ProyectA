using BE_ProyectoA.Core.Domain.Entities.Director;
using BE_ProyectoA.Core.Domain.Primitivies;
using BE_ProyectoA.Core.Domain.ValueObjects;
using ErrorOr;
using MediatR;

namespace BE_ProyectoA.Core.Application.Director.Commands.Create
{
    internal sealed class DirectorCreateCommandHandler : IRequestHandler<DirectorCreateCommand, ErrorOr<Unit>>
    {
        private readonly IDirectoresRepository _directorRepository;
        private readonly IUnitOfWork _unitOfWork;

        public DirectorCreateCommandHandler(IDirectoresRepository directorRepository,IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
            _directorRepository = directorRepository ?? throw new ArgumentNullException(nameof(directorRepository));
        }
        public async Task<ErrorOr<Unit>> Handle(DirectorCreateCommand command, CancellationToken cancellationToken)
        {

            if (NumeroTelefono.Create(command.NumeroTelefono) is not NumeroTelefono numeroTelefono)
                {
                return Error.Validation("Directores.NumeroTelefono", "El numero de telefono no esta en un formato valido");
                }
          
            if (Cedula.Create(command.Cedula ) is not Cedula cedula)
            {
                return Error.Validation("Directores.Cedula", "La Cedula no es valida");

            }
          
            var director = new Directores
                (
                    new DirectoresId(Guid.NewGuid()),
                    command.Nombre,
                    command.Apellido,
                    command.CantidadVotantes,
                    cedula,
                    numeroTelefono,
                    true

                );
            await _directorRepository.AddAsync(director);
            await _unitOfWork.SaveChangesAsync(cancellationToken);
            return Unit.Value;
                
        }
    }
}

