using BE_ProyectoA.Core.Domain.Entities.Coordinadores;
using BE_ProyectoA.Core.Domain.Primitivies;
using System.ComponentModel.DataAnnotations.Schema;

namespace BE_ProyectoA.Core.Domain.Entities.Votantes.VotantesSubCoordinadores
{
    public sealed class VotantesSubCoordinador : AggregateRoot
    {
        public VotanteId VotanteId { get; set; }
        public Votante Votante { get; set; }

        public SubCoordinadoresId SubCoordinadorId { get; set; }
        public SubCoordinadores SubCoordinador { get; set; }

        public VotantesSubCoordinador()
        {
            
        }

        public VotantesSubCoordinador(Guid subId, Guid voId )
        {
            SubCoordinadorId = new SubCoordinadoresId(subId);
            VotanteId = new VotanteId (voId);
        }
    }
}
