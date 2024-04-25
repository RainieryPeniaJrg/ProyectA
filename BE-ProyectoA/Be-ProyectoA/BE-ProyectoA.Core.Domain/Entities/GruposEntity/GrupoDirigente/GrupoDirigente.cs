using BE_ProyectoA.Core.Domain.Entities.DirigenteMultiplicador;
using BE_ProyectoA.Core.Domain.Primitivies;

namespace BE_ProyectoA.Core.Domain.Entities.GruposEntity.GrupoDirigente
{
    public class GrupoDirigente : AggregateRoot
    {
        public GruposId? GrupoId { get; set; }
        public Grupos? Grupo { get; set; }
        public DirigentesMultiplicadoresId? DirigenteId { get; set; }
        public DirigentesMultiplicadores? Dirigente { get; set; }
    }
}
