using BE_ProyectoA.Core.Domain.Entities.Coordinadores;
using BE_ProyectoA.Core.Domain.Primitivies;

namespace BE_ProyectoA.Core.Domain.Entities.GruposEntity.GrupoSubCoordinador
{
    public class GrupoSubCoordinador : AggregateRoot
    {
        public GruposId GrupoId { get; set; }
        public Grupos? Grupo { get; set; }
        public SubCoordinadoresId? SubCoordinadorId { get; set; }
        public SubCoordinadores? SubCoordinador { get; set; }
    }
}
