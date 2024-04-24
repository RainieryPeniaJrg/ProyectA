using BE_ProyectoA.Core.Domain.Entities.Coordinadores;
using BE_ProyectoA.Core.Domain.Entities.CoordinadorGeneral;
using BE_ProyectoA.Core.Domain.Entities.DirigenteMultiplicador;
using BE_ProyectoA.Core.Domain.Entities.GruposEntity;
using ErrorOr;
using MediatR;

namespace BE_ProyectoA.Core.Application.GrupoFeatures.Commands.Create
{
    public record CreateGruposCommand
 
        (
          Guid Id,
         string NombreGrupo,
         Guid DirigentesMultiplicadoresId,

         Guid SubCoordinadoresId,
 
        Guid CoordinadoresGeneralesId,
    

     bool Active
        
        )
        : IRequest<ErrorOr<Unit>>;
   
}
