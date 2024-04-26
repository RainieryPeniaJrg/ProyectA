using BE_ProyectoA.Core.Domain.Entities.Votantes;
using BE_ProyectoA.Core.Domain.Primitivies;
using BE_ProyectoA.Core.Domain.ValueObjects;

namespace BE_ProyectoA.Core.Domain.Entities.Director
{
    public sealed class Directores : AggregateRoot
    {
        public Directores() { }
        public Directores(DirectoresId id, string nombre, string apellido, CantidadVotos cantidadVotantes, Cedula cedula, NumeroTelefono numeroTelefono, bool activo)
        {
            Id = id;
            NumeroTelefono = numeroTelefono;
            Nombre = nombre;
            Apellido = apellido;
            Cedula = cedula;
            CantidadVotantes = cantidadVotantes;
            Activo = activo;
        
        }
      
        public DirectoresId Id { get; private set; }
        public string Nombre { get;  private set; } = string.Empty;
        public string Apellido { get; private set; } = string.Empty;
        public string NombreCompleto => $"{Nombre} {Apellido}";
        public CantidadVotos CantidadVotantes { get; set; }  
        public Cedula Cedula { get;  private  set; } 
        public NumeroTelefono NumeroTelefono { get; private set; }
        public bool Activo { get; set; }
        public ICollection<Votante> Votantes { get; set; }

        public static Directores? Update(DirectoresId id, string nombre, string apellido, CantidadVotos cantidadVotantes, Cedula cedula, NumeroTelefono numeroTelefono, bool activo)
        {
            return new Directores(id, nombre, apellido, cantidadVotantes, cedula, numeroTelefono, activo);
        }
    }
}
