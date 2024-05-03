using BE_ProyectoA.Core.Application.VotantesFeatures.VotantesSubCoordinadorFeatures.Common;
using BE_ProyectoA.Core.Domain.Entities.Votantes.VotantesSubCoordinadores;
using ErrorOr;
using MediatR;

namespace BE_ProyectoA.Core.Application.VotantesFeatures.VotantesSubCoordinadorFeatures.Queries.GetAll
{
    internal class GetAllVotantesSubCoordinadoresQueryHandler : IRequestHandler<GetAllVotantesSubCoordinadoresQuery, ErrorOr<IReadOnlyList<VotantesSubCoordinadorResponse>>>
    {
        private readonly IVotantesSubCoordiandoresRepository _repository;

        public GetAllVotantesSubCoordinadoresQueryHandler(IVotantesSubCoordiandoresRepository repository)
        {
            _repository = repository;
        }

        public async Task<ErrorOr<IReadOnlyList<VotantesSubCoordinadorResponse>>> Handle(GetAllVotantesSubCoordinadoresQuery request, CancellationToken cancellationToken)
        {
            var votantes = await _repository.GetAllVotantesSubCoordinador(cancellationToken);


            var response = votantes.Select(
                v => new VotantesSubCoordinadorResponse(
                    new VotantesSubCoordinadorResponseDTO(
                        v.Votante.Id.Value,
                        v.Votante.NombreCompleto,
                        v.Votante.Cedula,
                        v.Votante.NumeroTelefono,
                        new DireccionVotantesSubCoordinadorResponse(v.Votante.Direccion.Provincia,
                        v.Votante.Direccion.Sector),
                        v.Votante.Activo,
                        new SubCoordinadorResponse(v.SubCoordinador.NombreCompleto)


                ))).ToList();

            return response;

        }
    }
}
