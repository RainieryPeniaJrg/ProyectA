using BE_ProyectoA.Core.Domain.Entities.Votantes;
using ErrorOr;
using MediatR;


namespace BE_ProyectoA.Core.Application.VotantesFeatures.Commands.Create
{
    public record CreateVotanteCommand
        (
         string Nombre,
         string Apellido,
        int CantidadVotantes,
        string Cedula,
        string NumeroTelefono,
        bool Activo,
        string Sector,
        string Provincia,
        int CasaElectoral
        ) : IRequest<ErrorOr<Unit>>;

}
