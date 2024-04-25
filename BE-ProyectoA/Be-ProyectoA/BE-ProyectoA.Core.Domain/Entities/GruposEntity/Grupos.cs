using BE_ProyectoA.Core.Domain.Entities.Coordinadores;
using BE_ProyectoA.Core.Domain.Entities.CoordinadorGeneral;
using BE_ProyectoA.Core.Domain.Entities.DirigenteMultiplicador;
using BE_ProyectoA.Core.Domain.Primitivies;
using BE_ProyectoA.Core.Domain.ValueObjects;
using System.ComponentModel.DataAnnotations.Schema;


namespace BE_ProyectoA.Core.Domain.Entities.GruposEntity
{
    public sealed class Grupos : AggregateRoot
    {

        public GruposId Id { get; set; }
        public string NombreGrupo { get; set; }
        public ICollection<DirigentesMultiplicadores> DirigentesMultiplicadores { get; set; }
        public CoordinadoresGenerales CoordinadorGeneral { get; set; }
        public CoordinadoresGeneralesId CoordinadoresGeneralesId { get; set; }
        public ICollection<SubCoordinadores> SubCoordinadores { get; set; }
        public bool Active { get; set; }
        public CantidadVotos CantidadVotos  { get; set; }

        public Grupos() { }

        public Grupos(string nombreGrupo, GruposId id, ICollection<DirigentesMultiplicadores> dirigentesMultiplicadores, CoordinadoresGenerales coordinadoresGenerales, ICollection<SubCoordinadores> subCoordinadores, bool active)
        {
            Active = active;
            Id = id;
            NombreGrupo = nombreGrupo;
            DirigentesMultiplicadores = dirigentesMultiplicadores;
            CoordinadorGeneral = coordinadoresGenerales;
            SubCoordinadores = subCoordinadores;
        }

        public static Grupos? Update(string nombreGrupo, Guid id, ICollection<DirigentesMultiplicadores> dirigentesMultiplicadores, CoordinadoresGenerales coordinadoresGenerales, ICollection<SubCoordinadores> subCoordinadores, bool active)
        {
            return new Grupos(nombreGrupo, new GruposId(id), dirigentesMultiplicadores, coordinadoresGenerales, subCoordinadores, active);
        }




    }
}
