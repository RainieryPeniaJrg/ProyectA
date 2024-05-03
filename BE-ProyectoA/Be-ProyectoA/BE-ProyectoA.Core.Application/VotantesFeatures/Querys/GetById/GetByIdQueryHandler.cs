using BE_ProyectoA.Core.Application.VotantesFeatures.Commons;
using BE_ProyectoA.Core.Domain.Entities.Votantes;
using ErrorOr;
using MediatR;

namespace BE_ProyectoA.Core.Application.VotantesFeatures.Querys.GetById
{
    public class GetByIdQueryHandler : IRequestHandler<GetByIdVotantesQuery, ErrorOr<VotantesResponse>>
    {
        private readonly IVotanteRepository _votanteRepository;

        public GetByIdQueryHandler(IVotanteRepository votanteRepository)
        {
            _votanteRepository = votanteRepository ?? throw new ArgumentNullException(nameof(votanteRepository));
        }
        public async Task<ErrorOr<VotantesResponse>> Handle(GetByIdVotantesQuery query, CancellationToken cancellationToken)
        {
            var votante = await _votanteRepository.GetByIdWithMembers(query.Id, cancellationToken);

            if (votante == null)
            {
                // Aquí puedes manejar el caso en que el votante no se encuentre en la base de datos
                return Error.NotFound("Votante no encontrado");
            }

            var votanteResponse = new VotantesResponse(
                votante.Id.Value,
                votante.NombreCompleto,
                votante.Cedula,
                votante.NumeroTelefono,
                new DireccionResponse(votante.Direccion.Provincia, votante.Direccion.Sector),
                votante.Activo,
                votante.Director != null ? new DirectorResponse(votante.Director.Nombre, votante.Director.Apellido) : null,
                votante.SubCoordinador != null ? new SubCoordinadorResponse(votante.SubCoordinador.Nombre, votante.SubCoordinador.Apellido) : null,
                votante.CoordinadorGeneral != null ? new CoordinadorGeneralResponse(votante.CoordinadorGeneral.Nombre, votante.CoordinadorGeneral.Apellido) : null,
                votante.Dirigente != null ? new DirigenteMultiplicadorResponse(votante.Dirigente.Nombre, votante.Dirigente.Apellido) : null
            );

            return votanteResponse;

        }
    }
}

