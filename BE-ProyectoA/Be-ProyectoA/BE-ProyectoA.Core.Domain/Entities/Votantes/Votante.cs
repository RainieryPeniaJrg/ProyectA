using BE_ProyectoA.Core.Domain.Primitivies;
using BE_ProyectoA.Core.Domain.ValueObjects;

namespace BE_ProyectoA.Core.Domain.Entities.Votantes
{
    public sealed class Votante  : AggregateRoot
    {


        public Votante() { }


        public Votante(string nombre,string apellido, VotanteId id,Cedula cedula, Direccion direccion, NumeroTelefono numeroTelefono, bool activo)
        {
           Id = id;
            Nombre = nombre;
            Apellido = apellido;
            Cedula = cedula;
            Direccion = direccion;
            NumeroTelefono = numeroTelefono;
            Activo = activo;
        }
        public VotanteId Id { get; private set; }
        public string Nombre { get; private set; } = string.Empty;
        public string Apellido { get;private set; } = string.Empty;
        public string NombreCompleto => $"{Nombre} {Apellido}";
        public Cedula Cedula { get; private set; }
        public Direccion Direccion { get; private set; }
        public NumeroTelefono NumeroTelefono { get; private set; }
        public bool Activo { get; private set; }
        

    }
}
