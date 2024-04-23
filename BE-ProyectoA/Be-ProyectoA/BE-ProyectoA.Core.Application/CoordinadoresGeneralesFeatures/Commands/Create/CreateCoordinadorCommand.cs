




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
     int CantidadVotantes,
     bool Activo
        ) : IRequest<ErrorOr<Unit>>;

}

