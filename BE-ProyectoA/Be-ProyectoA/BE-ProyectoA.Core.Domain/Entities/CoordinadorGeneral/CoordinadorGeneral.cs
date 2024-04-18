using BE.MovieApp.Core.Domain.Primitivies;
using BE_ProyectoA.Core.Domain.ValueObjects;


namespace BE_ProyectoA.Core.Domain.Entities.CoordinadorGeneral
{
    public class CoordinadorGeneral  : AggregateRoot
    {

       public CoordinadorGeneral() { }
       public CoordinadorGeneral(CoordinadorGeneralId id, string nombre,string apellido, Cedula cedula, NumeroTelefono numeroTelefono, bool activo,Direccion direccion)    
        { 
            Id = id;
            Nombre = nombre;
            Apellido = apellido;
            Cedula = cedula;
            NumeroTelefono = numeroTelefono;
            Activo = activo;
            Direccion = direccion;

        }


        public CoordinadorGeneralId Id { get; set; }  
        public string Nombre { get; set; }  = string.Empty;
        public string Apellido { get; set; } = string.Empty;
        public string NombreCompleto => $"{Nombre} {Apellido}";
        public Cedula Cedula { get; set; }
        public NumeroTelefono NumeroTelefono { get; set; } 
        public Direccion Direccion { get; set; }
        public bool Activo { get; set; }

    }
}
