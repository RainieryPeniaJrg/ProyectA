




using BE_ProyectoA.Core.Domain.ValueObjects;
using ErrorOr;
using MediatR;

namespace BE_ProyectoA.Core.Application.CoordinadoresGeneralesFeatures.Commands.Create
{
    public record CreateCoordinadorCommand
        (
     string Nombre,
     string Apellido,
     string Cedula ,
     string NumeroTelefono,
     string Provincia,
     string Sector,
     string casaElectoral,
     CantidadVotos CantidadVotantes,
     bool Activo
        ) : IRequest<ErrorOr<Unit>>;

}

