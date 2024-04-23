using BE_ProyectoA.Core.Domain.Entities.Director;
using ErrorOr;
using MediatR;

namespace BE_ProyectoA.Core.Application.Director.Commands.Update
{
    public record UpdateDirectorCommand(
         DirectoresId Id,
         string Nombre,
         string Apellido,
         int CantidadVotantes,
         string Cedula,
         string NumeroTelefono,
         bool Activo,
         string Sector,
         string Provincia
        ) : IRequest<ErrorOr<Unit>>;

}
