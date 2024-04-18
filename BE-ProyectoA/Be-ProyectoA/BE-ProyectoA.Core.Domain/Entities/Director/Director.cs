using BE.MovieApp.Core.Domain.Primitivies;
using BE_ProyectoA.Core.Domain.ValueObjects;

namespace BE_ProyectoA.Core.Domain.Entities.Director
{
    public sealed class Director : AggregateRoot
    {

        public Director() { }

        public Director(DirectorId id, string nombre, string apellido, int cantidadVotantes, Cedula cedula, NumeroTelefono numeroTelefono, bool activo)
        {
            Id = id;
            NumeroTelefono = numeroTelefono;
            Nombre = nombre;
            Apellido = apellido;
            Cedula = cedula;
            CantidadVotantes = cantidadVotantes;
            Activo = activo;


        
        }
        public DirectorId Id { get; set; }
        public string Nombre { get;  private set; } = string.Empty;
        public string Apellido { get; private set; } = string.Empty;
        public string NombreCompleto => $"{Nombre} {Apellido}";
        public int CantidadVotantes { get; set; }  
        public Cedula Cedula { get;  private  set; } 
        public NumeroTelefono NumeroTelefono { get; private set; }
        public bool Activo { get; set; }
     
    }
}
