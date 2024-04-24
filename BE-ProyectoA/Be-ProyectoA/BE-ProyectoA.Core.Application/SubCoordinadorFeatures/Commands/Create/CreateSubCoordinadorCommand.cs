using BE_ProyectoA.Core.Domain.Entities.CoordinadorGeneral;
using BE_ProyectoA.Core.Domain.ValueObjects;
using ErrorOr;
using MediatR;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace BE_ProyectoA.Core.Application.SubCoordinadorFeatures.Commands.Create
{
    public record CreateSubCoordinadorCommand
        
        (


        string Nombre,
        string Apellido, 
    
      int CantidadVotantes ,
      string Cedula ,
      bool Activo,
      string Provincia,
      string Sector,
      int CasaElectoral,
      string NumeroTelefono,
      Guid CoordinadorGeneralId

        )
        : IRequest<ErrorOr<Unit>>;
    
}
