using ErrorOr;
using MediatR;

namespace BE_ProyectoA.Core.Application.CoordinadoresGeneralesFeatures.Commands.Update
{
   
        public record UpdateCoordinadorGeneralCommand
       (
           Guid Id,
    string Nombre,
    string Apellido,
    string Cedula,
    string NumeroTelefono,
    string Provincia,
    string Sector,
    int CasaElectoral,
    int CantidadVotantes,
    bool Activo
   

       ) : IRequest<ErrorOr<Unit>>;
   
}
