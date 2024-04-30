using BE_ProyectoA.Core.Domain.Entities.DirigenteMultiplicador;
using BE_ProyectoA.Core.Domain.Primitivies;

namespace BE_ProyectoA.Core.Domain.Entities.Votantes.VotantesDirigentesEntity
{
    public sealed class VotantesDirigentes : AggregateRoot
    {
        public VotantesDirigentes()
        {
            

        }

        public VotantesDirigentes(DirigentesMultiplicadoresId? dirigenteId, VotanteId? votanteId )
        {
            VotanteId = votanteId;
            DirigentesMultiplicadoresId = dirigenteId;
        }

        public VotanteId? VotanteId { get; set; }
        public Votante? Votante { get; set; }
        public DirigentesMultiplicadoresId? DirigentesMultiplicadoresId { get; set; }
        public DirigentesMultiplicadores? Dirigentes { get; set; }
    }
}
