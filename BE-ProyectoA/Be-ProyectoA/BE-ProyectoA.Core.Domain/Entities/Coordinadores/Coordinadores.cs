using BE.MovieApp.Core.Domain.Primitivies;
using BE_ProyectoA.Core.Domain.Entities.Coordinadores;
using BE_ProyectoA.Core.Domain.ValueObjects;

namespace BE_ProyectoA.Core.Domain.Entities.Coordinador
{
    public sealed class Coordinadores : AggregateRoot  
    {


        //constructor principal
        public Coordinadores() { }
        //contructor con parametros para quitar los nulo y 
        //usar el metodo actualizar
        public Coordinadores(CoordinadoresId id,string nombre, string apellido, int cantidadVotos, NumeroTelefono numeroTelefono, Cedula cedula, bool activo)
        {
            Id = id;
            Nombre = nombre;
            Apellido = apellido;
            Cedula = cedula;
            CantidadVotos = cantidadVotos;
            NumeroTelefono = numeroTelefono;
            Activo = activo;
            

        }
        public CoordinadoresId Id { get; set; }
        public string Nombre { get; set; }  = string.Empty;
        public string Apellido { get; set; } = string.Empty;
        public string NombreCompleto => $"{Nombre} {Apellido}";
        public int CantidadVotos { get; set; } 
        public Cedula Cedula { get; private set; } 
        public bool Activo {  get; private set; }   
        public NumeroTelefono NumeroTelefono { get; private set; }
    }
}
