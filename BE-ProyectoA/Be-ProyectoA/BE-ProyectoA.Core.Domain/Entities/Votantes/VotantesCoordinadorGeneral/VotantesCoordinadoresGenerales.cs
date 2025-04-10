﻿using BE_ProyectoA.Core.Domain.Entities.CoordinadorGeneral;
using BE_ProyectoA.Core.Domain.Primitivies;
using System.ComponentModel.DataAnnotations.Schema;

namespace BE_ProyectoA.Core.Domain.Entities.Votantes.VotantesCoordinadorGeneral
{
    public sealed class VotantesCoordinadoresGenerales : AggregateRoot
    {
        public VotanteId VotanteId { get; set; }
        public Votante Votante { get; set; }

        public CoordinadoresGeneralesId CoordinadorId { get; set; }
        public CoordinadoresGenerales Coordinador { get; set; }

        public VotantesCoordinadoresGenerales()
        {
            
        }
        public VotantesCoordinadoresGenerales(Guid coordinadoresGeneralesId, Guid votanteId)
        {
            VotanteId = new VotanteId(votanteId);
            CoordinadorId = new CoordinadoresGeneralesId(coordinadoresGeneralesId);
        }

    }
}
