using BE.MovieApp.Core.Domain.Primitivies;
using BE_ProyectoA.Core.Domain.ValueObjects;

namespace BE_ProyectoA.Core.Domain.Entities.Director
{
    public sealed class Director : AggregateRoot
    {
        public string Nombre { get;  private set; } = string.Empty;
        public string Apellido { get; private set; } = string.Empty;
        public string NombreCompleto => $"{Nombre} {Apellido}";
        public int CantidadVotos { get; set; }  
        public Cedula? Cedula { get;  private  set; } 
        public NumeroTelefono? NumeroTelefono { get; private set; }
     
    }
}
