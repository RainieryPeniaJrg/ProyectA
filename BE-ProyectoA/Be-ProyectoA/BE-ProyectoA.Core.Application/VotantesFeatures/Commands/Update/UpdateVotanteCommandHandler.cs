using BE_ProyectoA.Core.Application.Common.ValueObjectsValidators;
using BE_ProyectoA.Core.Domain.Entities.Coordinadores;
using BE_ProyectoA.Core.Domain.Entities.CoordinadorGeneral;
using BE_ProyectoA.Core.Domain.Entities.Director;
using BE_ProyectoA.Core.Domain.Entities.DirigenteMultiplicador;
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
            var votantedto = await _votantesRepository.GetByIdAsync(new VotanteId(command.Id), cancellationToken);

            if (votantedto == null)
            {
                // Manejar el caso en el que no se pueda encontrar el dirigente
                return Error.NotFound("Dirigente.NotFound", "El dirigente que seleccionó no se encuentra. Favor verificar el campo.");
            }


            var validationResult = ValueObjectValidators.ValidarDatos(command.Cedula, command.NumeroTelefono, command.Provincia, command.Sector, command.CasaElectoral);
            if (validationResult.IsError)
                return validationResult;

            var numeroTelefono = NumeroTelefono.Create(command.NumeroTelefono);

            var cedula = Cedula.Create(command.Cedula);

            var direccion = Direccion.Create(command.Provincia, command.Sector, command.CasaElectoral);

           

            if (await _votantesRepository.ExistsByCoordinadorGeneralAsync(new CoordinadoresGeneralesId(command.MiembroId), votantedto.Nombre, votantedto.Apellido, cancellationToken))
            {
                Votante votante = Votante.UpdateVotanteWithCoordinadorGeneral(command.Id, command.Nombre, command.Apellido, cedula, direccion, numeroTelefono, command.Activo,new CoordinadoresGeneralesId(command.MiembroId));
                _votantesRepository.Update2(votante);
                await _unitOfWork.SaveChangesAsync(cancellationToken);
            }

            if (await _votantesRepository.ExistsBySubCoordinadorAsync(new SubCoordinadoresId(command.MiembroId), votantedto.Nombre, votantedto.Apellido, cancellationToken))
            {
                Votante votante = Votante.UpdateVotanteWithSubCoordinador(command.Id, command.Nombre, command.Apellido, cedula, direccion, numeroTelefono, command.Activo, new SubCoordinadoresId(command.MiembroId));
                _votantesRepository.Update2(votante);
                await _unitOfWork.SaveChangesAsync(cancellationToken);
            }



            if (await _votantesRepository.ExistsByDirectorAsync(new DirectoresId(command.MiembroId), votantedto.Nombre, votantedto.Apellido, cancellationToken))
            {
                Votante votante = Votante.UpdateVotanteWithDirector(command.Id, command.Nombre, command.Apellido, cedula, direccion, numeroTelefono, command.Activo, new DirectoresId(command.MiembroId));
                _votantesRepository.Update2(votante);
                await _unitOfWork.SaveChangesAsync(cancellationToken);
            }


            if (await _votantesRepository.ExistsByDirigenteAsync(new DirigentesMultiplicadoresId(command.MiembroId), votantedto.Nombre, votantedto.Apellido, cancellationToken))
            {
                Votante votante = Votante.UpdateVotanteWithDirigente(command.Id, command.Nombre, command.Apellido, cedula, direccion, numeroTelefono, command.Activo, new DirigentesMultiplicadoresId(command.MiembroId));
                _votantesRepository.Update2(votante);
                await _unitOfWork.SaveChangesAsync(cancellationToken);
            }

            return Unit.Value;

        }



    }
}

