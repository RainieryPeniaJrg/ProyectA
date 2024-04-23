using BE_ProyectoA.Core.Domain.Entities.Votantes;
using BE_ProyectoA.Core.Domain.Primitivies;
using BE_ProyectoA.Core.Domain.ValueObjects;
using ErrorOr;
using MediatR;

namespace BE_ProyectoA.Core.Application.Votantes.Commands.Update
{
    public class UpdateVotanteCommandHandler : IRequestHandler<UpdateVotanteCommand, ErrorOr<Unit>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IVotantesRepository _votantesRepository;

        public UpdateVotanteCommandHandler(IUnitOfWork unitOfWork, IVotantesRepository votantesRepository)
        {
            _unitOfWork = unitOfWork;
            _votantesRepository = votantesRepository;
        }

        public async Task<ErrorOr<Unit>> Handle(UpdateVotanteCommand command, CancellationToken cancellationToken)
        {
            if(!await  _votantesRepository.ExistsAsync(new VotanteId(command.Id)))
            {
                return Error.NotFound("Votantes.NotFound", "The customer with the provide Id was not found.");
            }

            if (NumeroTelefono.Create(command.NumeroTelefono) is not NumeroTelefono numeroTelefono)
            {
                return Error.Validation("Votantes.NumeroTelefono", "El numero de telefono no esta en un formato valido");
            }

            if (Cedula.Create(command.Cedula) is not Cedula cedula)
            {
                return Error.Validation("Votantes.Cedula", "La Cedula no es valida");

            }

            if (Direccion.Create(command.Provincia, command.Sector) is not Direccion direccion)
            {
                return Error.Validation("Votantes.Direccion", "La Direccion no es valida");

            }

            Votante votante = Votante.UpdateVotante(command.Id, command.Nombre, command.Apellido, cedula, direccion, numeroTelefono, command.Activo); 

             _votantesRepository.Update(votante);
            await _unitOfWork.SaveChangesAsync(cancellationToken);
            return Unit.Value;

        }



    }
    }

