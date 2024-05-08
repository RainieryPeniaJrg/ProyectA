using BE_ProyectoA.Core.Application.Common.Enums;
using BE_ProyectoA.Core.Domain.Entities.Authentication;
using BE_ProyectoA.Core.Domain.Entities.Coordinadores;
using BE_ProyectoA.Core.Domain.Entities.CoordinadorGeneral;
using BE_ProyectoA.Core.Domain.Entities.Director;
using BE_ProyectoA.Core.Domain.Entities.DirigenteMultiplicador;
using BE_ProyectoA.Core.Domain.Entities.Votantes;
using BE_ProyectoA.Core.Domain.Entities.Votantes.VotantesCoordinadorGeneral;
using BE_ProyectoA.Core.Domain.Entities.Votantes.VotantesDirector;
using BE_ProyectoA.Core.Domain.Entities.Votantes.VotantesDirigentesEntity;
using BE_ProyectoA.Core.Domain.Entities.Votantes.VotantesSubCoordinadores;
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
        private readonly ICoordinadorGeneralRepository _coordinadorGeneralRepository;
        private readonly ISubCoordinadorRepository _subCoordinadorRepository;
        private readonly IDirigenteMultiplicadorRepository _dirigenteMultiplicadorRepository;
        private readonly IDirectoresRepository _directoresRepository;
        private readonly IVotanteCoordinadorRepository _VotanteCoordinadorRepository;
        private readonly IVotantesDirigenteRepository _VotantesDirigenteRepository;
        private readonly IVotantesSubCoordiandoresRepository _VotantesSubCoordiandoresRepository;
        private readonly IVotantesDirectorRepository _VotantesDirectorRepository;
        private readonly UserManager<ApplicationUser> _userManager;
        

        public CreateVotanteCommandHandler(IUnitOfWork unitOfWork, 
            IVotanteRepository votantesRepository, 
            ICoordinadorGeneralRepository coordinadorGeneralRepository, 
            ISubCoordinadorRepository subCoordinadorRepository, 
            IDirigenteMultiplicadorRepository dirigenteMultiplicadorRepository, 
            IDirectoresRepository directoresRepository, 
            UserManager<ApplicationUser> userManager, 
            IVotanteCoordinadorRepository votanteCoordinadorRepository, 
            IVotantesDirigenteRepository votantesDirigenteRepository, 
            IVotantesSubCoordiandoresRepository votantesSubCoordiandoresRepository,
            IVotantesDirectorRepository votantesDirectorRepository
            )
        {
            _unitOfWork = unitOfWork;
            _votantesRepository = votantesRepository;
            _coordinadorGeneralRepository = coordinadorGeneralRepository;
            _subCoordinadorRepository = subCoordinadorRepository;
            _dirigenteMultiplicadorRepository = dirigenteMultiplicadorRepository;
            _directoresRepository = directoresRepository;
            _userManager = userManager;
            _VotanteCoordinadorRepository = votanteCoordinadorRepository;
            _VotantesDirigenteRepository = votantesDirigenteRepository;
            _VotantesSubCoordiandoresRepository = votantesSubCoordiandoresRepository;
            _VotantesDirectorRepository = votantesDirectorRepository;
        }


        private async Task<bool> TryCreateDirectorVotante(CreateVotanteCommand command, ApplicationUser userRequest, Cedula? cedula, Direccion? direccion, NumeroTelefono? numeroTelefono, CancellationToken cancellationToken)
        {
            var directorGeneralId = new DirectoresId(Guid.Parse(userRequest.Id));
            if (!await  _directoresRepository.ExistsAsync(directorGeneralId, cancellationToken)) return false;


            // Verificar si el votante ya existe
            if (await _votantesRepository.ExistsByDirectorAsync(directorGeneralId, command.Nombre, command.Apellido, cancellationToken))
                return true;

            var votanteId = new VotanteId(Guid.NewGuid());
            var director = await _directoresRepository.GetByIdAsync(directorGeneralId, cancellationToken);
            if (director == null) return false;

            var votanteDirectorGeneral = new Votante(
                votanteId,
                command.Nombre,
                command.Apellido,
                cedula!,
                direccion!,
                numeroTelefono!,
                true,
                director.Id
            );


            var directorVotante = new VotantesDirectores(directorGeneralId.Value, votanteId.Value);
            await _votantesRepository.AddAsync(votanteDirectorGeneral, cancellationToken);
            await _VotantesDirectorRepository.AddAsync(directorVotante, cancellationToken);
            await _unitOfWork.SaveChangesAsync(cancellationToken);

            return true;
        }

        private async Task<bool> TryCreateCoordinadorGeneralVotante(CreateVotanteCommand command, ApplicationUser userRequest, Cedula? cedula, Direccion? direccion, NumeroTelefono? numeroTelefono, CancellationToken cancellationToken)
        {
            var coordinadorGeneralId = new CoordinadoresGeneralesId(Guid.Parse(userRequest.Id));
            if (!await _coordinadorGeneralRepository.ExistsAsync(coordinadorGeneralId, cancellationToken)) return false;

            // Verificar si el votante ya existe
            if (await _votantesRepository.ExistsByCoordinadorGeneralAsync(coordinadorGeneralId, command.Nombre, command.Apellido, cancellationToken))
                return true;

            var votanteId = new VotanteId(Guid.NewGuid());
            var coordinadorGeneral = await _coordinadorGeneralRepository.GetByIdAsync(coordinadorGeneralId, cancellationToken);
            if (coordinadorGeneral == null) return false;

            var votanteCoordinadorGeneral = new Votante(
                votanteId,
                command.Nombre,
                command.Apellido,
                cedula!,
                direccion!,
                numeroTelefono!,
                true,
                coordinadorGeneral.Id
            );


            var coordinadorVotante = new VotantesCoordinadoresGenerales(coordinadorGeneralId.Value, votanteId.Value);
            await _votantesRepository.AddAsync(votanteCoordinadorGeneral, cancellationToken);
            await _VotanteCoordinadorRepository.AddAsync(coordinadorVotante);
            await _unitOfWork.SaveChangesAsync(cancellationToken);

            return true;
        }

        private async Task<bool> TryCreateSubCoordinadorVotante(CreateVotanteCommand command, ApplicationUser userRequest, Cedula? cedula, Direccion? direccion, NumeroTelefono? numeroTelefono, CancellationToken cancellationToken)
        {
            var subCoordinadorId = new SubCoordinadoresId(Guid.Parse(userRequest.Id));
            if (!await _subCoordinadorRepository.ExistsAsync(subCoordinadorId, cancellationToken)) return false;

            // Verificar si el votante ya existe
            if (await _votantesRepository.ExistsBySubCoordinadorAsync(subCoordinadorId, command.Nombre, command.Apellido, cancellationToken))
                return true;
           
            var votanteId = new VotanteId(Guid.NewGuid());
            var subCoordinador = await _subCoordinadorRepository.GetByIdAsync2(subCoordinadorId, cancellationToken);
            if (subCoordinador == null) return false;

            var votanteSubCoordinador = new Votante(
                votanteId,
                command.Nombre,
                command.Apellido,
                cedula!,
                direccion!,
                numeroTelefono!,
                true,
                subCoordinador.Id
            );

            var subCoordinadorVotante = new VotantesSubCoordinador(subCoordinadorId.Value, votanteId.Value);
            
            await _votantesRepository.AddAsync(votanteSubCoordinador, cancellationToken);
            await _VotantesSubCoordiandoresRepository.AddAsync(subCoordinadorVotante, cancellationToken);
            await _unitOfWork.SaveChangesAsync(cancellationToken);

            return true;
        }

        private async Task<bool> TryCreateDirigenteVotante(CreateVotanteCommand command, ApplicationUser userRequest, Cedula? cedula, Direccion? direccion, NumeroTelefono? numeroTelefono, CancellationToken cancellationToken)
        {
            var votanteId = new VotanteId(Guid.NewGuid());
            var dirigenteId = new DirigentesMultiplicadoresId(Guid.Parse(userRequest.Id));
            if (!await _dirigenteMultiplicadorRepository.ExistsAsync(dirigenteId, cancellationToken)) return false;

            // Verificar si el votante ya existe
            if (await _votantesRepository.ExistsByDirigenteAsync(dirigenteId, command.Nombre, command.Apellido, cancellationToken))
                return true;

            var dirigente = await _dirigenteMultiplicadorRepository.GetByIdAsync(dirigenteId, cancellationToken);
            if (dirigente == null) return false;

            var votanteDirigente = new Votante(
                votanteId,
                command.Nombre,
                command.Apellido,
                cedula!,
                direccion!,
                numeroTelefono!,
                true,
                dirigente.Id
            );

            var dirigenteVotante = new VotantesDirigentes(dirigenteId.Value, votanteId.Value);
         
            await _votantesRepository.AddAsync(votanteDirigente, cancellationToken);
            await _VotantesDirigenteRepository.AddAsync(dirigenteVotante, cancellationToken);
            await _unitOfWork.SaveChangesAsync(cancellationToken);

            return true;
        }

        public async Task<ErrorOr<Unit>> Handle(CreateVotanteCommand command, CancellationToken cancellationToken)
        {
            var numeroTelefono = NumeroTelefono.Create(command.NumeroTelefono);
            var cedula = Cedula.Create(command.Cedula);
            var direccion = Direccion.Create(command.Provincia, command.Sector, command.CasaElectoral);
            var votantesList = await _votantesRepository.GetAll(cancellationToken);
            var userRequest = await _userManager.FindByIdAsync(command.MiembroId.ToString().ToLowerInvariant());

            if (userRequest == null) return Unit.Value;

            if (await TryCreateCoordinadorGeneralVotante(command, userRequest, cedula, direccion, numeroTelefono, cancellationToken))
            {
                await CalcularVotos(votantesList, command.MiembroId, TipoMiembro.CoordinadorGeneral, cancellationToken);
                return Unit.Value;
            }

            if (await TryCreateSubCoordinadorVotante(command, userRequest, cedula, direccion, numeroTelefono, cancellationToken))
            {
                await CalcularVotos(votantesList, command.MiembroId, TipoMiembro.SubCoordinador, cancellationToken);
                return Unit.Value;
            }

            if (await TryCreateDirigenteVotante(command, userRequest, cedula, direccion, numeroTelefono, cancellationToken))
            {
                await CalcularVotos(votantesList, command.MiembroId, TipoMiembro.DirigenteMultiplicador, cancellationToken);
                return Unit.Value;
            }

            if (await TryCreateDirectorVotante(command, userRequest, cedula, direccion, numeroTelefono, cancellationToken))
            {
                await CalcularVotos(votantesList, command.MiembroId, TipoMiembro.Director, cancellationToken);
                return Unit.Value;
            }

            return Unit.Value;
        }

        private async Task CalcularVotos(List<Votante> votantes, Guid miembroId, TipoMiembro tipoMiembro, CancellationToken cancellationToken)
        {
            switch (tipoMiembro)
            {
                case TipoMiembro.CoordinadorGeneral:
                    var coordinadorGeneralId = new CoordinadoresGeneralesId(miembroId);
                    if (await _coordinadorGeneralRepository.ExistsAsync(coordinadorGeneralId, cancellationToken))
                    {
                        var coordinadorGeneral = await _coordinadorGeneralRepository.GetByIdAsync(coordinadorGeneralId, cancellationToken);
                        if (coordinadorGeneral != null)
                        {
                            var votos = votantes.Count(v => v.CoordinadorGeneralId == coordinadorGeneralId) + 1;
                            if (votos == 0)
                                votos++;

                            var votosTotales = CantidadVotos.Create(votos);
                            var coordinador = CoordinadoresGenerales.UpdateWithOutRelationShip(
                                coordinadorGeneralId,
                                coordinadorGeneral.Nombre,
                                coordinadorGeneral.Apellido,
                                coordinadorGeneral.Cedula,
                                coordinadorGeneral.NumeroTelefono,
                                coordinadorGeneral.Direccion,
                                coordinadorGeneral.Activo,
                                votosTotales
                            );

                            _coordinadorGeneralRepository.Update(coordinador!);
                            await _unitOfWork.SaveChangesAsync(cancellationToken);

                        }
                    }
                    break;

                case TipoMiembro.SubCoordinador:
                    var subCoordinadorId = new SubCoordinadoresId(miembroId);
                    if (await _subCoordinadorRepository.ExistsAsync(subCoordinadorId, cancellationToken))
                    {
                        var subCoordinadorDto = await _subCoordinadorRepository.GetByIdAsync(subCoordinadorId, cancellationToken);
                        if (subCoordinadorDto != null)
                        {
                            var votos = votantes.Count(v => v.SubCoordinadorId == subCoordinadorId ) + 1;
                            if (votos == 0)
                                votos++;

                            var votosTotales = CantidadVotos.Create(votos);
                            var subCoordinador = SubCoordinadores.Update
                                (
                                subCoordinadorId,
                                subCoordinadorDto.Nombre,
                                subCoordinadorDto.Apellido,
                                votosTotales,
                                subCoordinadorDto.NumeroTelefono,
                                subCoordinadorDto.Cedula,
                                subCoordinadorDto.Activo,
                                subCoordinadorDto.Direccion,
                                subCoordinadorDto.CoordinadorsGeneralesId,
                                subCoordinadorDto.Coordinadores

                              );

                            _subCoordinadorRepository.Update(subCoordinador!);
                            await _unitOfWork.SaveChangesAsync(cancellationToken);
                        }
                    }
                    break;

                case TipoMiembro.DirigenteMultiplicador:
                    var dirigenteId = new DirigentesMultiplicadoresId(miembroId);
                    if (await _dirigenteMultiplicadorRepository.ExistsAsync(dirigenteId, cancellationToken))
                    {
                        var dirigenteDto = await _dirigenteMultiplicadorRepository.GetByIdAsync(dirigenteId, cancellationToken);
                        if (dirigenteDto != null)
                        {
                            var votos = votantes.Count(v => v.DirigenteId == dirigenteId) + 1;
                            if (votos == 0)
                                votos++;

                            var votosTotales = CantidadVotos.Create(votos);
                            var dirigente = DirigentesMultiplicadores.Update
                                (
                                dirigenteId,
                                dirigenteDto.Cedula,
                                dirigenteDto.NumeroTelefono,
                                dirigenteDto.Nombre,
                                dirigenteDto.Apellido,
                                dirigenteDto.Activo,
                                dirigenteDto.Direccion,
                                votosTotales,
                                dirigenteDto.SubCoordinadores,
                                dirigenteDto.SubCoordinadoresId
                               
                              );

                            _dirigenteMultiplicadorRepository.Update(dirigente!);
                            await _unitOfWork.SaveChangesAsync(cancellationToken);
                        }

                    }
                    break;

                case TipoMiembro.Director:
                    var directorId = new DirectoresId(miembroId);
                    if (await _directoresRepository.ExistsAsync(directorId, cancellationToken))
                    {
                        var directorDto = await _directoresRepository.GetByIdAsync(directorId, cancellationToken);

                        if (directorDto != null)
                        {
                            var votos = votantes.Count(v => v.DirectorId == directorId);
                            if (votos == 0)
                                votos++;

                            var votosTotales = CantidadVotos.Create(votos);
                            var directores = Directores.Update
                                (
                                    directorId,
                                    directorDto.Nombre,
                                    directorDto.Apellido,
                                    votosTotales,
                                    directorDto.Cedula,
                                    directorDto.NumeroTelefono,
                                    directorDto.Activo
                                   

                                );

                            _directoresRepository.Update(directores!);
                            await _unitOfWork.SaveChangesAsync(cancellationToken);
                        }
                    }
                    break;
            }
                   
        }
    }
}
