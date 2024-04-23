using MediatR;

namespace BE_ProyectoA.Core.Domain.Primitivies
{

    public record DomainEvents(Guid id) : INotification;

}
