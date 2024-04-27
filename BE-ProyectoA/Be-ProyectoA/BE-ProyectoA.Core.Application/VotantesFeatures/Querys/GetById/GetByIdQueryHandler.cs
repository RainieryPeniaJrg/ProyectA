//using BE_ProyectoA.Core.Application.VotantesFeatures.Commons;
//using BE_ProyectoA.Core.Domain.Entities.Votantes;
//using ErrorOr;
//using MediatR;
//using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

//namespace BE_ProyectoA.Core.Application.VotantesFeatures.Querys.GetById
//{
//    public class GetByIdQueryHandler : IRequestHandler<GetByIdVotantesQuery, ErrorOr<VotantesResponse>>
//    {
//        private readonly IVotanteRepository _votanteRepository;

//        public GetByIdQueryHandler(IVotanteRepository votanteRepository)
//        {
//            _votanteRepository = votanteRepository ?? throw new ArgumentNullException(nameof(votanteRepository));
//        }
//        public async Task<ErrorOr<VotantesResponse>> Handle(GetByIdVotantesQuery query, CancellationToken cancellationToken)
//        {
//            if (await _votanteRepository.GetByIdAsync(new VotanteId(query.Id), cancellationToken) is not Votante votante)
//            {
//                return Error.NotFound("Votantes.NotFound", "El votante con este id no ha sido encontrado");
//            }

//            return new VotantesResponse(
//                votante.Id.Value, votante.NombreCompleto, votante.Cedula, votante.NumeroTelefono,
//                new DireccionResponse(votante.Direccion.Provincia, votante.Direccion.Sector), votante.Activo);

//        }
//    }
//}

