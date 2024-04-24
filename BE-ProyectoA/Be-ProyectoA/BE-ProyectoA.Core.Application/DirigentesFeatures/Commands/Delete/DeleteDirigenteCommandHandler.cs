using BE_ProyectoA.Core.Domain.Entities.DirigenteMultiplicador;
using BE_ProyectoA.Core.Domain.Primitivies;
using ErrorOr;
using MediatR;

namespace BE_ProyectoA.Core.Application.DirigentesFeatures.Commands.Delete
{
    public class DeleteDirigenteCommandHandler: IRequestHandler<DeleteDirigenteCommand, ErrorOr<Unit>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IDirigenteMultiplicadorRepository _dirigenteMultiplicadorRepository;

        public DeleteDirigenteCommandHandler(IUnitOfWork unitOfWork, IDirigenteMultiplicadorRepository dirigenteMultiplicadorRepository)
        {
            _unitOfWork = unitOfWork;
            _dirigenteMultiplicadorRepository = dirigenteMultiplicadorRepository;
        }

        public async Task<ErrorOr<Unit>> Handle(DeleteDirigenteCommand command, CancellationToken cancellationToken)
        {
            if (await _dirigenteMultiplicadorRepository.GetByIdAsync(new DirigentesMultiplicadoresId(command.Id), cancellationToken) is not DirigentesMultiplicadores dirigente)
            {
                return Error.NotFound("Dirigente.NotFound", "El dirigente con id indicado no existe, favor revisar de nuevo");
            }

            _dirigenteMultiplicadorRepository.Delete(dirigente);

            await _unitOfWork.SaveChangesAsync(cancellationToken);

            return Unit.Value;




        }

        
    }
}
