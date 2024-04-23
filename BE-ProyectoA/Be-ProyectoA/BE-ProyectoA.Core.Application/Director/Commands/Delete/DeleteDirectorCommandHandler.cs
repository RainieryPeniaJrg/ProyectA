using BE_ProyectoA.Core.Domain.Entities.Director;
using BE_ProyectoA.Core.Domain.Primitivies;
using ErrorOr;
using MediatR;

namespace BE_ProyectoA.Core.Application.Director.Commands.Delete
{
    public class DeleteDirectorCommandHandler(IDirectoresRepository directorRepository, IUnitOfWork unitOfWork) : IRequestHandler<DeleteDirectorCommand, ErrorOr<Unit>>
    {

        private readonly IDirectoresRepository _directorRepository = directorRepository;
        private readonly IUnitOfWork _unitOfWork = unitOfWork;

        public async Task<ErrorOr<Unit>> Handle(DeleteDirectorCommand command, CancellationToken cancellationToken)
        {
            var user = await _directorRepository.GetEntityAsync();

            if(user != null) 
            {
                if(new DirectoresId(command.Id) != user.Id)
            {
                    return Error.NotFound("Director.NotFound", "director no encontrado");
                }
                await _directorRepository.RemoveAsync(user);
                await _unitOfWork.SaveChangesAsync(cancellationToken);
             
            }
            return Unit.Value;


        }
    }
}
