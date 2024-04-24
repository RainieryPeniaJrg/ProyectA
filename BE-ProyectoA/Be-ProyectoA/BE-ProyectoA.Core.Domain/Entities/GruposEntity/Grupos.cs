﻿using BE_ProyectoA.Core.Domain.Entities.Coordinadores;
using BE_ProyectoA.Core.Domain.Entities.CoordinadorGeneral;
using BE_ProyectoA.Core.Domain.Entities.DirigenteMultiplicador;
using BE_ProyectoA.Core.Domain.Primitivies;


namespace BE_ProyectoA.Core.Domain.Entities.GruposEntity
{
    public sealed class Grupos : AggregateRoot
    {
        public Grupos() { }

        public Grupos(string nombreGrupo, GruposId id, DirigentesMultiplicadoresId dirigentesMultiplicadoresId, DirigentesMultiplicadores dirigentesMultiplicadores, CoordinadoresGeneralesId coordinadoresGeneralesId, CoordinadoresGenerales coordinadoresGenerales, SubCoordinadoresId subCoordinadoresId, SubCoordinadores subCoordinadores, bool active)
        {
            Active = active;

            Id = id;
            NombreGrupo = nombreGrupo;

            DirigentesMultiplicadoresId = dirigentesMultiplicadoresId;
            DirigentesMultiplicadores = dirigentesMultiplicadores;

            SubCoordinadores = subCoordinadores;
            SubCoordinadoresId = subCoordinadoresId;

            CoordinadoresGenerales = coordinadoresGenerales;
            CoordinadoresGeneralesId = coordinadoresGeneralesId;

        }
        public GruposId Id { get; private set; }
        public string NombreGrupo { get; private set; }

        //propiedades de navegacion para relacion uno a muchos 
        public DirigentesMultiplicadoresId DirigentesMultiplicadoresId { get; private set; }
        public DirigentesMultiplicadores DirigentesMultiplicadores { get; private set; }

        //propiedades de navegacion para relacion uno a muchos 
        public SubCoordinadoresId SubCoordinadoresId { get; private set; }
        public SubCoordinadores SubCoordinadores { get; private set; }

        //propiedades de navegacion para relacion uno a muchos 
        public CoordinadoresGeneralesId CoordinadoresGeneralesId { get; private set; }
        public CoordinadoresGenerales CoordinadoresGenerales { get; private set; }

        public bool Active { get; private set; }

        public static Grupos? Update(string nombreGrupo, Guid id, DirigentesMultiplicadoresId dirigentesMultiplicadoresId, DirigentesMultiplicadores dirigentesMultiplicadores, CoordinadoresGeneralesId coordinadoresGeneralesId, CoordinadoresGenerales coordinadoresGenerales, SubCoordinadoresId subCoordinadoresId, SubCoordinadores subCoordinadores, bool active)
        {
            return new Grupos(nombreGrupo, new GruposId(id), dirigentesMultiplicadoresId, dirigentesMultiplicadores, coordinadoresGeneralesId, coordinadoresGenerales, subCoordinadoresId, subCoordinadores, active);
        }





    }
}
