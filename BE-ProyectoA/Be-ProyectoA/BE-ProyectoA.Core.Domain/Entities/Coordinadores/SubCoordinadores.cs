using BE_ProyectoA.Core.Domain.Entities.CoordinadorGeneral;
using BE_ProyectoA.Core.Domain.Entities.DirigenteMultiplicador;
using BE_ProyectoA.Core.Domain.Entities.GruposEntity;
using BE_ProyectoA.Core.Domain.Primitivies;
using BE_ProyectoA.Core.Domain.ValueObjects;

namespace BE_ProyectoA.Core.Domain.Entities.Coordinadores
{
    public sealed class SubCoordinadores : AggregateRoot
    {
        //constructor principal
        public SubCoordinadores() { }
        //contructor con parametros para quitar los nulo y 
        //usar el metodo actualizar
        public SubCoordinadores(SubCoordinadoresId id, string nombre, string apellido, int cantidadVotos, NumeroTelefono numeroTelefono, Cedula cedula, bool activo, Direccion direccion)
        {
            Id = id;
            Nombre = nombre;
            Apellido = apellido;
            Cedula = cedula;
            CantidadVotantes = cantidadVotos;
            NumeroTelefono = numeroTelefono;
            Activo = activo;
            Direccion = direccion;


        }


        public SubCoordinadores(SubCoordinadoresId id, string nombre, string apellido, int cantidadVotos, NumeroTelefono numeroTelefono, Cedula cedula, bool activo, Direccion direccion, CoordinadoresGeneralesId coordinadorsGeneralesId, CoordinadoresGenerales coordinadores, ICollection<DirigentesMultiplicadores> dirigentesMultiplicadores, ICollection<Grupos> grupos)
        {
            Id = id;
            Nombre = nombre;
            Apellido = apellido;
            Cedula = cedula;
            CantidadVotantes = cantidadVotos;
            NumeroTelefono = numeroTelefono;
            Activo = activo;
            Direccion = direccion;
            CoordinadorsGeneralesId = coordinadorsGeneralesId;
            Coordinadores = coordinadores;
            DirigentesMultiplicadores = dirigentesMultiplicadores;
            Grupos = grupos;
        }

        public SubCoordinadores(SubCoordinadoresId id, string nombre, string apellido, int cantidadVotos, NumeroTelefono numeroTelefono, Cedula cedula, bool activo, Direccion direccion, CoordinadoresGeneralesId coordinadorsGeneralesId, CoordinadoresGenerales coordinadores)
        {
            Id = id;
            Nombre = nombre;
            Apellido = apellido;
            Cedula = cedula;
            CantidadVotantes = cantidadVotos;
            NumeroTelefono = numeroTelefono;
            Activo = activo;
            Direccion = direccion;
            CoordinadorsGeneralesId = coordinadorsGeneralesId;
            Coordinadores = coordinadores;
          
        }
        public SubCoordinadores(SubCoordinadoresId id, string nombre, string apellido, int cantidadVotos, NumeroTelefono numeroTelefono, Cedula cedula, bool activo, Direccion direccion,CoordinadoresGenerales coordinadores)
        {
            Id = id;
            Nombre = nombre;
            Apellido = apellido;
            Cedula = cedula;
            CantidadVotantes = cantidadVotos;
            NumeroTelefono = numeroTelefono;
            Activo = activo;
            Direccion = direccion;
        
            Coordinadores = coordinadores;

        }
        public SubCoordinadoresId Id { get; set; }
        public string Nombre { get; set; } = string.Empty;
        public string Apellido { get; set; } = string.Empty;
        public string NombreCompleto => $"{Nombre} {Apellido}";
        public int CantidadVotantes { get; set; }
        public Cedula Cedula { get; private set; }
        public bool Activo { get; private set; }
        public Direccion Direccion { get; private set; }
        public NumeroTelefono NumeroTelefono { get; private set; }
        public ICollection<Grupos> Grupos { get; set; }
        public ICollection <DirigentesMultiplicadores> DirigentesMultiplicadores { get; set; }
        public CoordinadoresGeneralesId CoordinadorsGeneralesId { get; set; }
        public CoordinadoresGenerales Coordinadores { get; set; }   

        public static SubCoordinadores? Update(Guid id, string nombre, string apellido, int cantidadVotos, NumeroTelefono numeroTelefono, Cedula cedula, bool activo, Direccion direccion, CoordinadoresGeneralesId coordinadorsGeneralesId, CoordinadoresGenerales coordinadores, ICollection<DirigentesMultiplicadores> dirigentesMultiplicadores, ICollection<Grupos> grupos)
        {
            return new SubCoordinadores(new SubCoordinadoresId(id),nombre, apellido,cantidadVotos,numeroTelefono,cedula,activo, direccion, coordinadorsGeneralesId,coordinadores,dirigentesMultiplicadores,grupos);
        }
    }
}
