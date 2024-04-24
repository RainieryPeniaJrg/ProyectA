using BE_ProyectoA.Core.Application.Common.ValueObjectsValidators;
using BE_ProyectoA.Core.Domain.Entities.Votantes;
using BE_ProyectoA.Core.Domain.Primitivies;
using BE_ProyectoA.Core.Domain.ValueObjects;
using ErrorOr;
using MediatR;

namespace BE_ProyectoA.Core.Application.VotantesFeatures.Commands.Update
{
    public class UpdateVotanteCommandHandler : IRequestHandler<UpdateVotanteCommand, ErrorOr<Unit>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IVotanteRepository _votantesRepository;

        public UpdateVotanteCommandHandler(IUnitOfWork unitOfWork, IVotanteRepository votantesRepository)
        {
            _unitOfWork = unitOfWork;
            _votantesRepository = votantesRepository;
        }

        public async Task<ErrorOr<Unit>> Handle(UpdateVotanteCommand command, CancellationToken cancellationToken)
        {
            if (!await _votantesRepository.ExistsAsync(new VotanteId(command.Id), cancellationToken))
            {
                return Error.NotFound("Votantes.NotFound", "The customer with the provide Id was not found.");
            }

            var validationResult = ValueObjectValidators.ValidarDatos(command.Cedula, command.NumeroTelefono, command.Provincia, command.Sector, command.CasaElectoral);
            if (validationResult.IsError)
                return validationResult;

            var numeroTelefono = NumeroTelefono.Create(command.NumeroTelefono);

            var cedula = Cedula.Create(command.Cedula);

            var direccion = Direccion.Create(command.Provincia, command.Sector, command.CasaElectoral);

            Votante votante = Votante.UpdateVotante(command.Id, command.Nombre, command.Apellido, cedula, direccion, numeroTelefono, command.Activo);

            _votantesRepository.Update(votante);
            await _unitOfWork.SaveChangesAsync(cancellationToken);
            return Unit.Value;

        }



    }
}

