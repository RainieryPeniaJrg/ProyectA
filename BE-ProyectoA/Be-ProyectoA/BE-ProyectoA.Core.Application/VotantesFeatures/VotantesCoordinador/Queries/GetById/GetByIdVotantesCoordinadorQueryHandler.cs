using BE_ProyectoA.Core.Application.VotantesFeatures.VotantesCoordinador.Common;
using BE_ProyectoA.Core.Domain.Entities.Votantes.VotantesCoordinadorGeneral;
using ErrorOr;
using MediatR;

namespace BE_ProyectoA.Core.Application.VotantesFeatures.VotantesCoordinador.Queries.GetById
{
    internal class GetByIdVotantesCoordinadorQueryHandler : IRequestHandler<GetByIdVotantesCoordinadorQuery, ErrorOr<VotantesCoordinadorResponse>>
    {
        private readonly IVotanteCoordinadorRepository _repository;

        public GetByIdVotantesCoordinadorQueryHandler(IVotanteCoordinadorRepository repository)
        {
            _repository = repository;
        }

        public async Task<ErrorOr<VotantesCoordinadorResponse>> Handle(GetByIdVotantesCoordinadorQuery request, CancellationToken cancellationToken)
        {
            var votante = await _repository.GetByIdWithMembers(request.Id, cancellationToken);

            if (votante == null)
            {

                return Error.NotFound("VotanteDirigente no encontrado");
            }

            var votanteResponseDTO = new VotantesCoordinadorResponse(
                new VotantesResponse(votante.Votante.Id.Value, votante.Votante.NombreCompleto, votante.Votante.Cedula, votante.Votante.NumeroTelefono, 
                new DireccionResponse(votante.Votante.Direccion.Provincia,
                votante.Votante.Direccion.Sector), votante.Votante.Activo, 
                new CoordinadorGeneralResponse(votante.Coordinador.Nombre, 
                votante.Coordinador.Apellido))
            ); ;

         
            return votanteResponseDTO;
        }
    }
 }

