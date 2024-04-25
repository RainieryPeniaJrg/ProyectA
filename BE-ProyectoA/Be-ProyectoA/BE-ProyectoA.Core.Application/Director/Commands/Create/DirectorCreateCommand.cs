using BE_ProyectoA.Core.Domain.Entities.Director;
using BE_ProyectoA.Core.Domain.ValueObjects;
using ErrorOr;
using MediatR;


namespace BE_ProyectoA.Core.Application.Director.Commands.Create
{
    public record DirectorCreateCommand
        (
      
         string Nombre,
         string Apellido,
        CantidadVotos CantidadVotantes,
        string Cedula,
        string NumeroTelefono,
        bool Activo,
        string Sector,
        string Provincia
        ) : IRequest<ErrorOr<Unit>>;
    
}
