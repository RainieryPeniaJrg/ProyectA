using BE.MovieApp.Core.Domain.Primitivies;
using BE_ProyectoA.Core.Domain.Entities.Coordinadores;
using BE_ProyectoA.Core.Domain.ValueObjects;

namespace BE_ProyectoA.Core.Domain.Entities.Coordinador
{
    public sealed class Coordinadores : AggregateRoot  
    {

        public CoordinadoresId Id { get; set; }
        public string Nombre { get; set; }  = string.Empty;
        public string Apellido { get; set; } = string.Empty;
        public int CantidadVotos { get; set; } 
        public Cedula Cedula { get; private set; }  
        public NumeroTelefono NumeroTelefono { get; private set; }
    }
}
