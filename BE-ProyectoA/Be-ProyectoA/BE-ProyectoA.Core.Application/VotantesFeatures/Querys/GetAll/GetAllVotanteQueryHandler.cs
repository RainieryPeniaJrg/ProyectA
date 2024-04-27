using BE_ProyectoA.Core.Application.VotantesFeatures.Commons;
using BE_ProyectoA.Core.Domain.Entities.Votantes;
using ErrorOr;
using MediatR;
using System.Linq;

namespace BE_ProyectoA.Core.Application.VotantesFeatures.Querys.GetAll
{
    public class GetAllVotanteQueryHandler : IRequestHandler<GetAllVotanteQuery, ErrorOr<IReadOnlyList<VotantesResponse>>>
    {
        private readonly IVotanteRepository _votanteRepository;

        public GetAllVotanteQueryHandler(IVotanteRepository votanteRepository)
        {
            _votanteRepository = votanteRepository ?? throw new ArgumentNullException(nameof(votanteRepository));
        }

        public async Task<ErrorOr<IReadOnlyList<VotantesResponse>>> Handle(GetAllVotanteQuery query, CancellationToken cancellationToken)
        {
            var votantes = await _votanteRepository.GetAllWithMembers(cancellationToken);

            var votantesResponse = votantes.Select(user => new VotantesResponse(
                user.Id.Value,
                user.NombreCompleto,
                user.Cedula,
                user.NumeroTelefono,
                new DireccionResponse(user.Direccion.Provincia, user.Direccion.Sector),
                user.Activo,
                user.Director != null ? new DirectorResponse(user.Director.Nombre, user.Director.Apellido) : null,
                user.SubCoordinador != null ? new SubCoordinadorResponse(user.SubCoordinador.Nombre, user.SubCoordinador.Apellido) : null,
                user.CoordinadorGeneral != null ? new CoordinadorGeneralResponse(user.CoordinadorGeneral.Nombre, user.CoordinadorGeneral.Apellido) : null,
                user.Dirigente != null ? new DirigenteMultiplicadorResponse(user.Dirigente.Nombre, user.Dirigente.Apellido) : null
            )).ToList();

            return votantesResponse;


        }
    }
}
