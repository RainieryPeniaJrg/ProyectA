using BE_ProyectoA.Core.Application.Votantes.Commons;
using BE_ProyectoA.Core.Application.Votantes.Querys.GetById;
using BE_ProyectoA.Core.Domain.Entities.Votantes;
using BE_ProyectoA.Core.Domain.ValueObjects;
using ErrorOr;
using MediatR;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace BE_ProyectoA.Core.Application.Votantes.Querys.GetByCedulaQuery
{
    public class GetByCedulaQueryHandler : IRequestHandler<GetByCedulaQuery, ErrorOr<VotantesResponse>>
    {

        private readonly IVotanteRepository _votanteRepository;

        public GetByCedulaQueryHandler(IVotanteRepository votanteRepository)
        {
            _votanteRepository = votanteRepository;
        }

        public async Task<ErrorOr<VotantesResponse>> Handle(GetByCedulaQuery query, CancellationToken cancellationToken)
        {
            var votante = (await _votanteRepository.GetBy(v => v.Cedula == Cedula.Create(query.Cedula), cancellationToken)).FirstOrDefault();

            if (votante == null)
            {
                return Error.NotFound("Votantes.NotFound", "El votante con esta cédula no ha sido encontrado");
            }

            return new VotantesResponse(
                votante.Id.Value, votante.NombreCompleto, votante.Cedula, votante.NumeroTelefono,
                new DireccionResponse(votante.Direccion.Provincia, votante.Direccion.Sector), votante.Activo);
        }
    }
}
