using ErrorOr;
using MediatR;

namespace BE_ProyectoA.Core.Application.VotantesFeatures.Commands.Update
{
    public record UpdateVotanteCommand
        (
         Guid Id,
         string Nombre,
         string Apellido,
        int CantidadVotantes,
        string Cedula,
        string NumeroTelefono,
        bool Activo,
        string Sector,
        string Provincia,
        string CasaElectoral,
        Guid MiembroId
        ) : IRequest<ErrorOr<Unit>>;

}
