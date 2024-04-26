using BE_ProyectoA.Core.Domain.Entities.CoordinadorGeneral;
using BE_ProyectoA.Core.Domain.Entities.Director;
using BE_ProyectoA.Core.Domain.Entities.DirigenteMultiplicador;
using BE_ProyectoA.Core.Domain.Entities.Votantes;
using System.ComponentModel.DataAnnotations.Schema;

namespace BE_ProyectoA.Core.Domain.ValueObjects
{
    [NotMapped]
    public partial record CantidadVotos
    {
        private CantidadVotos(int value) => Value = value;

        public static CantidadVotos Create(int value)
        {
            return new CantidadVotos(value);
        }

        public int Value { get; init; }

        public static CantidadVotos CalcularCantidadVotos(List<Votante> votantes, Guid miembroId)
        {
            var coordinadorGeneralId = new CoordinadoresGeneralesId(miembroId);

            int cantidadVotos = votantes.Count(v => v.CoordinadorGeneralId == coordinadorGeneralId);
            return new CantidadVotos(cantidadVotos);
        }
    }
  }

