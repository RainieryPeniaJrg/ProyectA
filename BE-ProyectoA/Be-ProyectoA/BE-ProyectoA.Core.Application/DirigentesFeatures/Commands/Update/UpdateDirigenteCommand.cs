using ErrorOr;
using MediatR;

namespace BE_ProyectoA.Core.Application.DirigentesFeatures.Commands.Update
{
    public record UpdateDirigenteCommand
        (
     Guid Id,
     string Nombre,
     string Apellido,
     int CantidadVotantes,
     string Cedula,
     string NumeroTelefono,
     string Provincia,
     string Sector,
     int CasaElectoral,
     bool Activo,
     Guid SubCoordinadoresId

        )

        :
        IRequest<ErrorOr<Unit>>;
   
}
