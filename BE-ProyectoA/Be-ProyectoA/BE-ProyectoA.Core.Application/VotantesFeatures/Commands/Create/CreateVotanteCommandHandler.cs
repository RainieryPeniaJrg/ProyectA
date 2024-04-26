using BE_ProyectoA.Core.Application.Interfaces;
using BE_ProyectoA.Core.Domain.Entities.Authentication;
using BE_ProyectoA.Core.Domain.Entities.Coordinadores;
using BE_ProyectoA.Core.Domain.Entities.CoordinadorGeneral;
using BE_ProyectoA.Core.Domain.Entities.Director;
using BE_ProyectoA.Core.Domain.Entities.DirigenteMultiplicador;
using BE_ProyectoA.Core.Domain.Entities.Votantes;
using BE_ProyectoA.Core.Domain.Primitivies;
using BE_ProyectoA.Core.Domain.ValueObjects;
using ErrorOr;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace BE_ProyectoA.Core.Application.VotantesFeatures.Commands.Create
{
    public class CreateVotanteCommandHandler(IUnitOfWork unitOfWork,
        IVotanteRepository votantesRepository,
        IAccount account,
        ICoordinadorGeneralRepository coordinadorGeneralRepository,
        UserManager<ApplicationUser> userManager,
        ISubCoordinadorRepository subCoordinadorRepository,
        IDirigenteMultiplicadorRepository dirigenteMultiplicadorRepository,
        IDirectoresRepository directoresRepository
            ) : IRequestHandler<CreateVotanteCommand, ErrorOr<Unit>>
    {
        private readonly IUnitOfWork _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
        private readonly IVotanteRepository _votantesRepository = votantesRepository ?? throw new ArgumentNullException(nameof(votantesRepository));

        public async Task<ErrorOr<Unit>> Handle(CreateVotanteCommand command, CancellationToken cancellationToken)
        {
            var numeroTelefono = NumeroTelefono.Create(command.NumeroTelefono);
            var cedula = Cedula.Create(command.Cedula);
            var direccion = Direccion.Create(command.Provincia, command.Sector, command.CasaElectoral);

            var userRequest = await userManager.FindByIdAsync(command.MiembroId.ToString().ToLowerInvariant());

            if (userRequest != null)
            {
              
                var dirigenteId = new DirigentesMultiplicadoresId(Guid.Parse(userRequest.Id));
                var subCoordinadorId = new SubCoordinadoresId(Guid.Parse(userRequest.Id));
                var directorId = new DirectoresId(Guid.Parse(userRequest.Id));
                var coordinadorGeneralId = new CoordinadoresGeneralesId(Guid.Parse(userRequest.Id));

                if (await coordinadorGeneralRepository.ExistsAsync(coordinadorGeneralId, cancellationToken))
                {
                    var coordinadorGeneral = await coordinadorGeneralRepository.GetByIdAsync(coordinadorGeneralId, cancellationToken);

                    if(coordinadorGeneral != null)
                    {
                        var votanteCoordinadorGeneral = new Votante(
                         new VotanteId(Guid.NewGuid()),
                            command.Nombre,
                           command.Apellido,
                           cedula!,
                           direccion!,
                           numeroTelefono!,
                           true,
                           coordinadorGeneral.Id
              );

                        await _votantesRepository.AddAsync(votanteCoordinadorGeneral, cancellationToken);
                        await _unitOfWork.SaveChangesAsync(cancellationToken);

                        return Unit.Value;
                    }
                   

                }

                if (await subCoordinadorRepository.ExistsAsync(subCoordinadorId, cancellationToken))
                {
                    var subCoordinador = await subCoordinadorRepository.GetByIdAsync(subCoordinadorId, cancellationToken);

                    if (subCoordinador != null)
                    {
                        var votanteCoordinadorGeneral = new Votante(
                         new VotanteId(Guid.NewGuid()),
                            command.Nombre,
                           command.Apellido,
                           cedula!,
                           direccion!,
                           numeroTelefono!,
                           true,
                           subCoordinador.Id
              );

                        await _votantesRepository.AddAsync(votanteCoordinadorGeneral, cancellationToken);
                        await _unitOfWork.SaveChangesAsync(cancellationToken);

                        return Unit.Value;
                    }
                }

                if(await dirigenteMultiplicadorRepository.ExistsAsync(dirigenteId, cancellationToken))
                {
                    var dirigente = await dirigenteMultiplicadorRepository.GetByIdAsync(dirigenteId,cancellationToken);

                    if (dirigente != null)
                    {
                        var votanteCoordinadorGeneral = new Votante(
                         new VotanteId(Guid.NewGuid()),
                            command.Nombre,
                           command.Apellido,
                           cedula!,
                           direccion!,
                           numeroTelefono!,
                           true,
                           dirigente.Id
              );

                        await _votantesRepository.AddAsync(votanteCoordinadorGeneral, cancellationToken);
                        await _unitOfWork.SaveChangesAsync(cancellationToken);

                        return Unit.Value;
                    }
                }

            }
            
            return Unit.Value;
        }

    }
}
