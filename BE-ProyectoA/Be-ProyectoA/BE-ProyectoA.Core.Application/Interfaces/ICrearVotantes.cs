using BE_ProyectoA.Core.Application.Common.Enums;
using BE_ProyectoA.Core.Domain.Entities.Votantes;

namespace BE_ProyectoA.Core.Application.Interfaces
{
    public interface ICrearVotantes
    {
        void CalcularVotos(List<Votante> votantes, Guid miembroId, TipoMiembro tipoMiembro ,CancellationToken cancellationToken);
     
    
    }
}
