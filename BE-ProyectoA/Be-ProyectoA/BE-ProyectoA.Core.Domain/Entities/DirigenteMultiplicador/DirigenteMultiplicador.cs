using BE.MovieApp.Core.Domain.Primitivies;
using BE_ProyectoA.Core.Domain.ValueObjects;

namespace BE_ProyectoA.Core.Domain.Entities.DirigenteMultiplicador
{
    public sealed class DirigenteMultiplicador : AggregateRoot
    {
        public string Nombre { get; set; } = string.Empty;
        public string Apellido { get; set; } = string.Empty;
        public int CantidadVotos { get; set; }
        public Cedula? Cedula { get; private set; }
        public NumeroTelefono? NumeroTelefono { get; private set; }



    }
}
