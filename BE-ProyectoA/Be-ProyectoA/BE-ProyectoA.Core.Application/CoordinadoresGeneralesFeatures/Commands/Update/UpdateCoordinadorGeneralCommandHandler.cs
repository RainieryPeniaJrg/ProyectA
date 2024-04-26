using BE_ProyectoA.Core.Application.Common.ValueObjectsValidators;
using BE_ProyectoA.Core.Domain.Entities.CoordinadorGeneral;
using BE_ProyectoA.Core.Domain.Entities.Votantes;
using BE_ProyectoA.Core.Domain.Primitivies;
using BE_ProyectoA.Core.Domain.ValueObjects;
using ErrorOr;
using MediatR;

namespace BE_ProyectoA.Core.Application.CoordinadoresGeneralesFeatures.Commands.Update
{
    public class UpdateCoordinadorGeneralCommandHandler : IRequestHandler<UpdateCoordinadorGeneralCommand, ErrorOr<Unit>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ICoordinadorGeneralRepository _coordinadorGeneralRepository;

        public UpdateCoordinadorGeneralCommandHandler(IUnitOfWork unitOfWork, ICoordinadorGeneralRepository coordinadorGeneralRepository)
        {
            _unitOfWork = unitOfWork;
            _coordinadorGeneralRepository = coordinadorGeneralRepository;
        }

        public async Task<ErrorOr<Unit>> Handle(UpdateCoordinadorGeneralCommand command, CancellationToken cancellationToken)
        {
            if(! await _coordinadorGeneralRepository.ExistsAsync(new CoordinadoresGeneralesId(command.Id)))
                {

                return Error.Validation("CoordinadorGeneral.NotFound", "El coordinador proporcionador no se encuentra");
            }

            var validationResult = ValueObjectValidators.ValidarDatos(command.Cedula, command.NumeroTelefono, command.Provincia, command.Sector,command.CasaElectoral);
            if (validationResult.IsError)
                return validationResult;

            var numeroTelefono = NumeroTelefono.Create(command.NumeroTelefono);
            var cedula = Cedula.Create(command.Cedula);
            var direccion = Direccion.Create(command.Provincia, command.Sector,command.CasaElectoral);

            var coordinadores = CoordinadoresGenerales.UpdateWithOutRelationShipAndWithOutVotes(command.Id, command.Nombre,
                                                                                                    command.Apellido,
                                                                                                    cedula,
                                                                                                    numeroTelefono,
                                                                                                    direccion,
                                                                                           command.Activo);

            _coordinadorGeneralRepository.Update(coordinadores);
            await _unitOfWork.SaveChangesAsync(cancellationToken);
            return Unit.Value;

        }
    }
}
