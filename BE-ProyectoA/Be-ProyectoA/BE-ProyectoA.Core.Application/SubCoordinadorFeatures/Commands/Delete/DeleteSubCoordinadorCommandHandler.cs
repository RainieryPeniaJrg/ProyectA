using BE_ProyectoA.Core.Domain.Entities.Coordinadores;
using BE_ProyectoA.Core.Domain.Entities.DirigenteMultiplicador;
using BE_ProyectoA.Core.Domain.Primitivies;
using ErrorOr;
using MediatR;

namespace BE_ProyectoA.Core.Application.SubCoordinadorFeatures.Commands.Delete
{
    public class DeleteSubCoordinadorCommandHandler : IRequestHandler<DeleteSubCoordinadorCommand, ErrorOr<Unit>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ISubCoordinadorRepository _subCoordinadorRepository;

        public DeleteSubCoordinadorCommandHandler(IUnitOfWork unitOfWork, ISubCoordinadorRepository subCoordinadorRepository)
        {
            _unitOfWork = unitOfWork;
            _subCoordinadorRepository = subCoordinadorRepository;
        }

        public async Task<ErrorOr<Unit>> Handle(DeleteSubCoordinadorCommand command, CancellationToken cancellationToken)
        {
            if (await _subCoordinadorRepository.GetByIdAsync(new SubCoordinadoresId(command.Id), cancellationToken) is not SubCoordinadores dirigente)
            {
                return Error.NotFound("SubCoordinador.NotFound", "El SubCoordinador con id indicado no existe, favor revisar de nuevo");
            }

            _subCoordinadorRepository.Delete(dirigente);

            await _unitOfWork.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
