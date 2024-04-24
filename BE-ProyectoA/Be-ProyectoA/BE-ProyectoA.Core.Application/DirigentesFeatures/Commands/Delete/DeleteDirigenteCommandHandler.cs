using ErrorOr;
using MediatR;

namespace BE_ProyectoA.Core.Application.DirigentesFeatures.Commands.Delete
{
    public class DeleteDirigenteCommandHandler() : IRequestHandler<DeleteDirigenteCommand, ErrorOr<Unit>>
    {
        public Task<ErrorOr<Unit>> Handle(DeleteDirigenteCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        
    }
}
