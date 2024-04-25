using BE_ProyectoA.Core.Domain.Entities.Coordinadores;
using BE_ProyectoA.Core.Domain.Entities.CoordinadorGeneral;
using BE_ProyectoA.Core.Domain.Entities.Director;
using BE_ProyectoA.Core.Domain.Entities.DirigenteMultiplicador;
using BE_ProyectoA.Core.Domain.Primitivies;
using BE_ProyectoA.Core.Domain.ValueObjects;

namespace BE_ProyectoA.Core.Domain.Entities.Votantes
{
    public sealed class Votante : AggregateRoot
    {


        public Votante() { }


        public Votante(VotanteId id, string nombre, string apellido, Cedula cedula, Direccion direccion, NumeroTelefono numeroTelefono, bool activo)
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
        public string Apellido { get; private set; } = string.Empty;
        public string NombreCompleto => $"{Nombre} {Apellido}";
        public Cedula Cedula { get; private set; }
        public Direccion Direccion { get; private set; }
        public NumeroTelefono NumeroTelefono { get; private set; }
        public bool Activo { get; private set; }

        public Directores Director { get; set; }
        public DirectoresId DirectorId { get; set; }
        public SubCoordinadores SubCoordinador { get; set; }
        public SubCoordinadoresId SubCoordinadorId { get; set; }
        public CoordinadoresGenerales CoordinadorGeneral { get; set; }
        public CoordinadoresGeneralesId CoordinadorGeneralId { get; set; }
        public DirigentesMultiplicadores Dirigente { get; set; }
        public DirigentesMultiplicadoresId DirigenteId { get; set; }

        public static Votante UpdateVotante(Guid Id, string nombre,string apellido,Cedula cedula,Direccion direccion, NumeroTelefono numeroTelefono,bool activo)
        {
            return new Votante(new VotanteId(Id),nombre, apellido, cedula, direccion, numeroTelefono, activo);
        }
        

    }
}
