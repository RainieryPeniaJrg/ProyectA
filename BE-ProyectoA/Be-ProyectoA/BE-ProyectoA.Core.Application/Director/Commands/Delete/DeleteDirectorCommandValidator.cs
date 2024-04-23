using FluentValidation;

namespace BE_ProyectoA.Core.Application.Director.Commands.Delete
{
    public class DeleteDirectorCommandValidator : AbstractValidator<DeleteDirectorCommand>
    {
        public DeleteDirectorCommandValidator()
        {
            RuleFor(r=>r.Id).NotEmpty();
        }
    }
}
