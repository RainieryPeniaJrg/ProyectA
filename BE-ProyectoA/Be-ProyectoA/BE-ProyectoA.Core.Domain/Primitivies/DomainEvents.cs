using MediatR;

namespace BE.MovieApp.Core.Domain.Primitivies
{

    public record DomainEvents(Guid id) : INotification;

}
