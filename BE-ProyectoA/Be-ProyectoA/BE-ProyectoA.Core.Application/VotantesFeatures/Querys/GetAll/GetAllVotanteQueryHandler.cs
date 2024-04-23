using BE_ProyectoA.Core.Application.Votantes.Commons;
using BE_ProyectoA.Core.Domain.Entities.Votantes;
using ErrorOr;
using MediatR;

namespace BE_ProyectoA.Core.Application.Votantes.Querys.GetAll
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
            IReadOnlyList<Votante> votantes = await _votanteRepository.GetAll(cancellationToken);
            
            return votantes.Select
                (user=> new VotantesResponse (user.Id.Value, user.Nombre, user.Cedula, 
                user.NumeroTelefono, new DireccionResponse(user.Direccion.Sector,user.Direccion.Sector),user.Activo)).ToList();
           
        
        }
    }
}
