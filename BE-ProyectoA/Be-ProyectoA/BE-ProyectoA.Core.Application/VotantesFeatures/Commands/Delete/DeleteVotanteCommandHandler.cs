using BE_ProyectoA.Core.Domain.Entities.Votantes;
using BE_ProyectoA.Core.Domain.Primitivies;
using ErrorOr;
using MediatR;

namespace BE_ProyectoA.Core.Application.VotantesFeatures.Commands.Delete
{
    public class DeleteVotanteCommandHandler : IRequestHandler<DeleteVotanteCommand, ErrorOr<Unit>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IVotanteRepository _votantesRepository;

        public DeleteVotanteCommandHandler(IUnitOfWork unitOfWork, IVotanteRepository votantesRepository)
        {
            _unitOfWork = unitOfWork;
            _votantesRepository = votantesRepository;
        }

        public async Task<ErrorOr<Unit>> Handle(DeleteVotanteCommand command, CancellationToken cancellationToken)
        {
            if (await _votantesRepository.GetByIdAsync(new VotanteId(command.Id), cancellationToken) is not Votante votante)
            {
                return Error.NotFound("Customer.NotFound", "The customer with the provide Id was not found.");
            }

            _votantesRepository.Delete(votante);

            await _unitOfWork.SaveChangesAsync(cancellationToken);

            return Unit.Value;



        }
    }
}
