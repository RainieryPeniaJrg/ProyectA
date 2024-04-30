using BE_ProyectoA.Core.Domain.Entities.DirigenteMultiplicador;
using BE_ProyectoA.Core.Domain.Primitivies;
using System.ComponentModel.DataAnnotations.Schema;

namespace BE_ProyectoA.Core.Domain.Entities.Votantes.VotantesDirigentesEntity
{
    public sealed class VotantesDirigentes : AggregateRoot
    {
        public VotantesDirigentes()
        {
            

        }

        public VotantesDirigentes(Guid dirigenteId, Guid votanteId )
        {
            VotanteId = new VotanteId(votanteId);
            DirigenteId = new DirigentesMultiplicadoresId(dirigenteId);
        }
        public VotanteId VotanteId { get; set; }
        public Votante Votante { get; set; }

        public DirigentesMultiplicadoresId DirigenteId { get; set; }
        public DirigentesMultiplicadores Dirigente { get; set; }
    }
}
