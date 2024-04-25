using BE_ProyectoA.Core.Application.Common.ValueObjectsValidators;
using BE_ProyectoA.Core.Application.Extensions;
using BE_ProyectoA.Core.Application.Interfaces;
using BE_ProyectoA.Core.Domain.Entities.Authentication;
using BE_ProyectoA.Core.Domain.Entities.CoordinadorGeneral;
using BE_ProyectoA.Core.Domain.Entities.Votantes;
using BE_ProyectoA.Core.Domain.Primitivies;
using BE_ProyectoA.Core.Domain.ValueObjects;
using ErrorOr;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace BE_ProyectoA.Core.Application.VotantesFeatures.Commands.Create
{
    public class CreateVotanteCommandHandler : IRequestHandler<CreateVotanteCommand, ErrorOr<Unit>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IVotanteRepository _votantesRepository;
        private readonly IAccount _account;
        private readonly ICoordinadorGeneralRepository _coordinadorGeneralRepository;
        private readonly UserManager<ApplicationUser> _userManager;

        public CreateVotanteCommandHandler(IUnitOfWork unitOfWork,
            IVotanteRepository votantesRepository,
                IAccount account,
            ICoordinadorGeneralRepository coordinadorGeneralRepository,
            UserManager<ApplicationUser> userManager
            )
        {
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
            _votantesRepository = votantesRepository ?? throw new ArgumentNullException(nameof(votantesRepository));
            _account = account;
            _coordinadorGeneralRepository = coordinadorGeneralRepository;
            _userManager = userManager;
        }

        public async Task<ErrorOr<Unit>> Handle(CreateVotanteCommand command, CancellationToken cancellationToken)
        {

            var userRequest = await _userManager.FindByIdAsync(command.MiembroId.ToString().ToLowerInvariant());
            // Validar los datos de entrada
            var validationResult = ValueObjectValidators.ValidarDatos(command.Cedula, command.NumeroTelefono, command.Provincia, command.Sector, command.CasaElectoral);
            if (validationResult.IsError)
                return validationResult;

            var numeroTelefono = NumeroTelefono.Create(command.NumeroTelefono);
            var cedula = Cedula.Create(command.Cedula);
            var direccion = Direccion.Create(command.Provincia, command.Sector, command.CasaElectoral);
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

 
            await _votantesRepository.AddAsync(votante, cancellationToken);
            await _unitOfWork.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }




    }
}
