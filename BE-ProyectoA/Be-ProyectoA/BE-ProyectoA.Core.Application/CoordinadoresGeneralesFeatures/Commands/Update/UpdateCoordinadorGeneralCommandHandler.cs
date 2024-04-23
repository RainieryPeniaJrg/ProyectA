using BE_ProyectoA.Core.Domain.Entities.CoordinadorGeneral;
using BE_ProyectoA.Core.Domain.Primitivies;
using ErrorOr;
using MediatR;

namespace BE_ProyectoA.Core.Application.CoordinadoresGeneralesFeatures.Commands.Update
{
    public class UpdateCoordinadorGeneralCommandHandler : IRequestHandler<UpdateCoordinadorGeneralCommand, ErrorOr<Unit>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ICoordinadorGeneralRepository _coordinadorGeneralRepository;

        public UpdateCoordinadorGeneralCommandHandler(IUnitOfWork unitOfWork, ICoordinadorGeneralRepository coordinadorGeneralRepository)
        {
            _unitOfWork = unitOfWork;
            _coordinadorGeneralRepository = coordinadorGeneralRepository;
        }

        public async Task<ErrorOr<Unit>> Handle(UpdateCoordinadorGeneralCommand command, CancellationToken cancellationToken)
        {
            if(! await _coordinadorGeneralRepository.ExistsAsync(new CoordinadoresGeneralesId(command.Id)))
                {

                return Error.Validation("CoordinadorGeneral.NotFound", "El coordinador proporcionador no se encuentra");
            }

            throw new NotImplementedException();
        }
    }
}
