using BE_ProyectoA.Core.Application.VotantesFeatures.VotantesDirector.Common;
using BE_ProyectoA.Core.Domain.Entities.Votantes.VotantesDirector;
using ErrorOr;
using MediatR;

namespace BE_ProyectoA.Core.Application.VotantesFeatures.VotantesDirector.Queries.GetByMemberId
{
    internal class GetByMemberIdVotantesDirectorQueryHandler : IRequestHandler<GetByMemberIdVotantesDirectorQuery, ErrorOr<IReadOnlyList<VotantesDirectorResponse>>>
    {
        private readonly IVotantesDirectorRepository _repository;

        public GetByMemberIdVotantesDirectorQueryHandler(IVotantesDirectorRepository repository)
        {
            _repository = repository;
        }

        public async Task<ErrorOr<IReadOnlyList<VotantesDirectorResponse>>> Handle(GetByMemberIdVotantesDirectorQuery request, CancellationToken cancellationToken)
        {
            var votanteDirector = await _repository.GetByMemberId(request.Id, cancellationToken);

            var response = votanteDirector.Select(
                           v => new VotantesDirectorResponse(
                               new VotantesDirectorResponseDTO(
                                   v.Votante.Id.Value,
                                   v.Votante.NombreCompleto,
                                   v.Votante.Cedula,
                                   v.Votante.NumeroTelefono,
                                   new DireccionVotantesDirectorResponse(
                                   v.Votante.Direccion.Provincia,
                                   v.Votante.Direccion.Sector),
                                   v.Votante.Activo,
                                   new DirectorResponse(v.Director.NombreCompleto)

                           ))).ToList();


            return response;
        }
    }
}
