using BE_ProyectoA.Core.Domain.Entities.Coordinadores;
using BE_ProyectoA.Core.Domain.Entities.CoordinadorGeneral;
using BE_ProyectoA.Core.Domain.Entities.Director;
using BE_ProyectoA.Core.Domain.Entities.DirigenteMultiplicador;
using BE_ProyectoA.Core.Domain.Entities.Votantes.VotantesCoordinadorGeneral;
using BE_ProyectoA.Core.Domain.Entities.Votantes.VotantesDirector;
using BE_ProyectoA.Core.Domain.Entities.Votantes.VotantesDirigentesEntity;
using BE_ProyectoA.Core.Domain.Entities.Votantes.VotantesSubCoordinadores;
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

    
        public Votante(VotanteId id, string nombre, string apellido, Cedula cedula, Direccion direccion, NumeroTelefono numeroTelefono, bool activo,CoordinadoresGeneralesId miembroId)
        {
            Id = id;
            Nombre = nombre;
            Apellido = apellido;
            Cedula = cedula;
            Direccion = direccion;
            NumeroTelefono = numeroTelefono;
            Activo = activo;
            CoordinadorGeneralId = miembroId;
        }

        public Votante(VotanteId id, string nombre, string apellido, Cedula cedula, Direccion direccion, NumeroTelefono numeroTelefono, bool activo, SubCoordinadoresId miembroId)
        {
            Id = id;
            Nombre = nombre;
            Apellido = apellido;
            Cedula = cedula;
            Direccion = direccion;
            NumeroTelefono = numeroTelefono;
            Activo = activo;
            SubCoordinadorId = miembroId;
        }

        public Votante(VotanteId id, string nombre, string apellido, Cedula cedula, Direccion direccion, NumeroTelefono numeroTelefono, bool activo, DirigentesMultiplicadoresId miembroId)
        {
            Id = id;
            Nombre = nombre;
            Apellido = apellido;
            Cedula = cedula;
            Direccion = direccion;
            NumeroTelefono = numeroTelefono;
            Activo = activo;
            DirigenteId = miembroId;
        }

        public Votante(VotanteId id, string nombre, string apellido, Cedula cedula, Direccion direccion, NumeroTelefono numeroTelefono, bool activo, DirectoresId miembroId)
        {
            Id = id;
            Nombre = nombre;
            Apellido = apellido;
            Cedula = cedula;
            Direccion = direccion;
            NumeroTelefono = numeroTelefono;
            Activo = activo;
            DirectorId = miembroId;
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
        public ICollection<VotantesDirectores> VotantesDirector { get; set; }  
        public ICollection<VotantesDirigentes> VotantesDirigentes { get; set; }
        public ICollection<VotantesCoordinadoresGenerales> VotantesCoordinadoresGenerales { get; set; }
        public  ICollection<VotantesSubCoordinador> VotantesSubCoordinador { get; set; }  
        public static Votante UpdateVotante(Guid Id, string nombre,string apellido,Cedula cedula,Direccion direccion, NumeroTelefono numeroTelefono,bool activo)
        {
            return new Votante(new VotanteId(Id),nombre, apellido, cedula, direccion, numeroTelefono, activo);
        }

        public static Votante UpdateVotanteWithCoordinadorGeneral (Guid Id, string nombre, string apellido, Cedula cedula, Direccion direccion, NumeroTelefono numeroTelefono, bool activo, CoordinadoresGeneralesId miembroId)
        {
            return new Votante(new VotanteId(Id), nombre, apellido, cedula, direccion, numeroTelefono, activo, miembroId);
        }

        public static Votante UpdateVotanteWithSubCoordinador(Guid Id, string nombre, string apellido, Cedula cedula, Direccion direccion, NumeroTelefono numeroTelefono, bool activo, SubCoordinadoresId miembroId)
        {
            return new Votante(new VotanteId(Id), nombre, apellido, cedula, direccion, numeroTelefono, activo,miembroId);
        }

        public static Votante UpdateVotanteWithDirector(Guid Id, string nombre, string apellido, Cedula cedula, Direccion direccion, NumeroTelefono numeroTelefono, bool activo,DirectoresId miembroId)
        {
            return new Votante(new VotanteId(Id), nombre, apellido, cedula, direccion, numeroTelefono, activo, miembroId);
        }

        public static Votante UpdateVotanteWithDirigente(Guid Id, string nombre, string apellido, Cedula cedula, Direccion direccion, NumeroTelefono numeroTelefono, bool activo,DirigentesMultiplicadoresId miembroId)
        {
            return new Votante(new VotanteId(Id), nombre, apellido, cedula, direccion, numeroTelefono, activo,miembroId);
        }


    }
}
