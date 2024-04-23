using BE_ProyectoA.Core.Domain.Entities.CoordinadorGeneral;
using BE_ProyectoA.Core.Domain.Entities.Votantes;
using BE_ProyectoA.Core.Domain.Primitivies;
using ErrorOr;
using MediatR;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace BE_ProyectoA.Core.Application.CoordinadoresGeneralesFeatures.Commands.Delete
{
    public class DeleteCoordinadorCommandHandler : IRequestHandler<DeleteCoordinadorCommand, ErrorOr<Unit>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ICoordinadorGeneralRepository _coordinadorGeneralRepository;

        public DeleteCoordinadorCommandHandler(IUnitOfWork unitOfWork, ICoordinadorGeneralRepository coordinadorGeneralRepository)
        {
            _unitOfWork = unitOfWork?? throw new ArgumentNullException(nameof(unitOfWork));
            _coordinadorGeneralRepository = coordinadorGeneralRepository ?? throw new ArgumentException(nameof(coordinadorGeneralRepository)); 
        }

        public async Task<ErrorOr<Unit>> Handle(DeleteCoordinadorCommand command, CancellationToken cancellationToken)
        {
            if (await _coordinadorGeneralRepository.GetByIdAsync(new CoordinadoresGeneralesId(command.Id)) is not CoordinadoresGenerales coordinador)
            {
                return Error.NotFound("Customer.NotFound", "The customer with the provide Id was not found.");
            }

            _coordinadorGeneralRepository.Delete(coordinador);

            await _unitOfWork.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
