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

    }
  }

