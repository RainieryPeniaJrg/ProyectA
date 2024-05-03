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
            var coordinadorGeneralId = new CoordinadoresGeneralesId(command.Id);

            if (!await _coordinadorGeneralRepository.ExistsAsync(coordinadorGeneralId, cancellationToken))
            {
                return Error.Validation("CoordinadorGeneral.NotFound", "El coordinador proporcionado no se encuentra");
            }

            var coordinadorGeneral = await _coordinadorGeneralRepository.GetByIdAsync(coordinadorGeneralId, cancellationToken);

            if (coordinadorGeneral == null)
            {
                // Manejar el caso en el que no se pueda encontrar el coordinador general
                return Error.Validation("CoordinadorGeneral.NotFound", "El coordinador proporcionado no se encuentra");
            }

         
            var votosTotales = CantidadVotos.Create(command.CantidadVotantes);

            // Actualizar los datos del coordinador general con los nuevos datos proporcionados
            var coordinadorToUpdate = CoordinadoresGenerales.UpdateWithOutRelationShip(
                coordinadorGeneralId,
                command.Nombre,
                command.Apellido,
                coordinadorGeneral.Cedula,
                coordinadorGeneral.NumeroTelefono,
                coordinadorGeneral.Direccion,
                command.Activo,
                votosTotales
            );

            // Utilizar el método Update del repositorio genérico para actualizar el coordinador general
            _coordinadorGeneralRepository.Update(coordinadorToUpdate!);

            // Guardar los cambios en la base de datos
            await _unitOfWork.SaveChangesAsync(cancellationToken);

            return Unit.Value;

        }
    }
}
