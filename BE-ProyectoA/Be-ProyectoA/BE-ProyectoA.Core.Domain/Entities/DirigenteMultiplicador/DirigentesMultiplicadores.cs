using BE.MovieApp.Core.Domain.Primitivies;
using BE_ProyectoA.Core.Domain.ValueObjects;

namespace BE_ProyectoA.Core.Domain.Entities.DirigenteMultiplicador
{
    public sealed class DirigentesMultiplicadores : AggregateRoot
    {
        //constructor
        public DirigentesMultiplicadores() { }

        //constructor para inicilizar los atributos
        public DirigentesMultiplicadores(DirigentesMultiplicadoresId id,Cedula cedula,NumeroTelefono numeroTelefono, string nombre,string apellido,bool activo, Direccion direccion, int cantidadVotantes)
        {
            Id = id;
            Nombre = nombre;
            Apellido = apellido;
            Cedula = cedula;
            NumeroTelefono = numeroTelefono;
            Activo = activo;
            Direccion = direccion;
            CantidadVotantes = cantidadVotantes;
        }
        public DirigentesMultiplicadoresId Id { get; set; }
        public string Nombre { get; set; } = string.Empty;
        public string Apellido { get; set; } = string.Empty;
        public string NombreCompleto => $"{Nombre} {Apellido}";
        public int CantidadVotantes { get; set; }
        public Cedula Cedula { get; private set; }
        public NumeroTelefono NumeroTelefono { get; private set; }
        public Direccion Direccion { get; set; }
        public bool Activo { get;  private set; }

    }
}
