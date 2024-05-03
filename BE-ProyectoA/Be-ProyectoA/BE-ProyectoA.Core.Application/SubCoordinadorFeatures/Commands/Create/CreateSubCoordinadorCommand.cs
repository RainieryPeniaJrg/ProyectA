using BE_ProyectoA.Core.Domain.ValueObjects;
using ErrorOr;
using MediatR;

namespace BE_ProyectoA.Core.Application.SubCoordinadorFeatures.Commands.Create
{
    public record CreateSubCoordinadorCommand 
        (

     string Nombre,
     string Apellido,
     int CantidadVotos,
     string Cedula,
     bool Activo,
     string Provincia,
     string Sector,
     string CasaElectoral,
     string NumeroTelefono,
     Guid CoordinadorsGeneralesId 
        ):IRequest<ErrorOr<Unit>>;
   
}
