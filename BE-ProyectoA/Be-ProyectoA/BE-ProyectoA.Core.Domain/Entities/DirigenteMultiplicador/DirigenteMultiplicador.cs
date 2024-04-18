using BE.MovieApp.Core.Domain.Primitivies;
using BE_ProyectoA.Core.Domain.ValueObjects;

namespace BE_ProyectoA.Core.Domain.Entities.DirigenteMultiplicador
{
    public sealed class DirigenteMultiplicador : AggregateRoot
    {

        //constructor
        public DirigenteMultiplicador() { }

        //constructor para inicilizar los atributos
        public DirigenteMultiplicador(DirigenteMultiplicadorId id,Cedula cedula,NumeroTelefono numeroTelefono, string nombre,string apellido,bool activo)
        {
            Id = id;
            Nombre = nombre;
            Apellido = apellido;
            Cedula = cedula;
            NumeroTelefono = numeroTelefono;
            Activo = activo;
        }
        public DirigenteMultiplicadorId Id { get; set; }
        public string Nombre { get; set; } = string.Empty;
        public string Apellido { get; set; } = string.Empty;
        public string NombreCompleto => $"{Nombre} {Apellido}";
        public int CantidadVotos { get; set; }
        public Cedula Cedula { get; private set; }
        public NumeroTelefono NumeroTelefono { get; private set; }
        public bool Activo { get;  private set; }

    }
}
