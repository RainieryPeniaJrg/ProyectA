using BE_ProyectoA.Core.Application.Common.ValueObjectsValidators;
using BE_ProyectoA.Core.Domain.Entities.Coordinadores;
using BE_ProyectoA.Core.Domain.Entities.DirigenteMultiplicador;
using BE_ProyectoA.Core.Domain.Primitivies;
using BE_ProyectoA.Core.Domain.ValueObjects;
using ErrorOr;
using MediatR;

namespace BE_ProyectoA.Core.Application.DirigentesFeatures.Commands.Create
{
    public class CreateDirigentesCommandHandler : IRequestHandler<CreateDirigentesCommand, ErrorOr<Unit>>
    {
        private readonly IUnitOfWork _unitOfOfWork;
        private readonly IDirigenteMultiplicadorRepository _dirigenteMultiplicadorRepository;
        private readonly ISubCoordinadorRepository _subCoordinadorRepository;

        public CreateDirigentesCommandHandler(IUnitOfWork unitOfOfWork, IDirigenteMultiplicadorRepository dirigenteMultiplicadorRepository, ISubCoordinadorRepository subCoordinadorRepository)
        {
            _unitOfOfWork = unitOfOfWork;
            _dirigenteMultiplicadorRepository = dirigenteMultiplicadorRepository;
            _subCoordinadorRepository = subCoordinadorRepository;
        }
        public async Task<ErrorOr<Unit>> Handle(CreateDirigentesCommand command, CancellationToken cancellationToken)
        {
            // Validar los datos de entrada
            var validationResult = ValueObjectValidators.ValidarDatos(command.Cedula, command.NumeroTelefono, command.Provincia, command.Sector, command.CasaElectoral);
            if (validationResult.IsError)
                return validationResult;

            var numeroTelefono = NumeroTelefono.Create(command.NumeroTelefono);

            var cedula = Cedula.Create(command.Cedula);

            var direccion = Direccion.Create(command.Provincia, command.Sector, command.CasaElectoral);

            var IpSubCoordinador = new SubCoordinadoresId(command.SubCoordinadoresId);

            if(!await _subCoordinadorRepository.ExistsAsync(IpSubCoordinador, cancellationToken))
            {
                return Error.Validation("SubCoordinadores.NotFound", "El SubCoordinadores proporcionador no se encuentra");
            }

            var subCoordinador = await _subCoordinadorRepository.GetByIdAsync(IpSubCoordinador, cancellationToken);   
            
            if(subCoordinador != null)
            {
                var dirigente = new DirigentesMultiplicadores
              (
              new DirigentesMultiplicadoresId(Guid.NewGuid()),cedula, numeroTelefono,
              command.Nombre, command.Apellido, command.Activo, 
              direccion, command.CantidadVotantes,subCoordinador
               
              );
                await _dirigenteMultiplicadorRepository.AddAsync(dirigente, cancellationToken);
            }


            await _unitOfOfWork.SaveChangesAsync(cancellationToken);

           return Unit.Value;
        }
    }
}
