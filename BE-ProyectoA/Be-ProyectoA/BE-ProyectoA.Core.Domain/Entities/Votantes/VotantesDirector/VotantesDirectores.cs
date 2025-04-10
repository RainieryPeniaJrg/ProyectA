﻿using BE_ProyectoA.Core.Domain.Entities.Director;
using BE_ProyectoA.Core.Domain.Primitivies;
using System.ComponentModel.DataAnnotations.Schema;

namespace BE_ProyectoA.Core.Domain.Entities.Votantes.VotantesDirector
{
    public class VotantesDirectores : AggregateRoot
    {
        public VotanteId VotanteId { get; set; }
        public Votante Votante { get; set; }

        public DirectoresId DirectorId { get; set; }
        public Directores Director { get; set; }
        public VotantesDirectores()
        {
            
        }

        public VotantesDirectores(Guid directorId, Guid votanteId)
        {
            DirectorId = new DirectoresId(directorId);

            VotanteId = new VotanteId(votanteId);
        }
    }
}
