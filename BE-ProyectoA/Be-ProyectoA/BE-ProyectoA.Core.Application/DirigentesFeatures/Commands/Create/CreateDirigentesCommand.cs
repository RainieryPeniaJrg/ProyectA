using BE_ProyectoA.Core.Domain.Entities.Coordinadores;
using BE_ProyectoA.Core.Domain.Entities.DirigenteMultiplicador;
using BE_ProyectoA.Core.Domain.Entities.GruposEntity;
using BE_ProyectoA.Core.Domain.ValueObjects;
using ErrorOr;
using MediatR;

namespace BE_ProyectoA.Core.Application.DirigentesFeatures.Commands.Create
{
    public record CreateDirigentesCommand(
  
     string Nombre ,
     string Apellido,
     CantidadVotos CantidadVotantes,
     string Cedula,
     string NumeroTelefono,
     string Provincia,
     string Sector,
     int CasaElectoral,
     bool Activo,
     Guid SubCoordinadoresId


        ): IRequest<ErrorOr<Unit>>;

 

}
