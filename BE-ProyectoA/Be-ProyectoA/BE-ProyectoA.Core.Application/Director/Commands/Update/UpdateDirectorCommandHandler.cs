
using BE_ProyectoA.Core.Domain.Entities.Director;
using ErrorOr;
using MediatR;

namespace BE_ProyectoA.Core.Application.Director.Commands.Update
{
    public class UpdateDirectorCommandHandler : IRequestHandler<UpdateDirectorCommand, ErrorOr<Unit>>
    {
        public Task<ErrorOr<Unit>> Handle(UpdateDirectorCommand command, CancellationToken cancellationToken)
        {
           

            throw new NotImplementedException();
        }
    }
}
