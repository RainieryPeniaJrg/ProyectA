using BE_ProyectoA.Core.Domain.Entities.Coordinadores;
using BE_ProyectoA.Core.Domain.Entities.GruposEntity;
using BE_ProyectoA.Core.Domain.Entities.Votantes;
using BE_ProyectoA.Core.Domain.Entities.Votantes.VotantesDirigentesEntity;
using BE_ProyectoA.Core.Domain.Primitivies;
using BE_ProyectoA.Core.Domain.ValueObjects;

namespace BE_ProyectoA.Core.Domain.Entities.DirigenteMultiplicador
{
    public sealed class DirigentesMultiplicadores : AggregateRoot
    {
        //constructor
        public DirigentesMultiplicadores() { }

        //constructor para inicilizar los atributos
        public DirigentesMultiplicadores(DirigentesMultiplicadoresId id,Cedula cedula,NumeroTelefono numeroTelefono, string nombre,string apellido,bool activo, Direccion direccion, CantidadVotos cantidadVotantes)
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

        public DirigentesMultiplicadores(DirigentesMultiplicadoresId id, Cedula cedula, NumeroTelefono numeroTelefono, string nombre, string apellido, bool activo, Direccion direccion, CantidadVotos cantidadVotantes, SubCoordinadoresId subCoordinadoresId, SubCoordinadores subCoordinadores, ICollection<Grupos> grupos)
        {
            Id = id;
            Nombre = nombre;
            Apellido = apellido;
            Cedula = cedula;
            NumeroTelefono = numeroTelefono;
            Activo = activo;
            Direccion = direccion;
            CantidadVotantes = cantidadVotantes;
            Grupos = grupos;
            SubCoordinadores = subCoordinadores;
            SubCoordinadoresId = subCoordinadoresId;
        }

        public DirigentesMultiplicadores(DirigentesMultiplicadoresId id, Cedula cedula, NumeroTelefono numeroTelefono, string nombre, string apellido, bool activo, Direccion direccion, CantidadVotos cantidadVotantes, SubCoordinadoresId subCoordinadoresId, SubCoordinadores subCoordinadores)
        {
            Id = id;
            Nombre = nombre;
            Apellido = apellido;
            Cedula = cedula;
            NumeroTelefono = numeroTelefono;
            Activo = activo;
            Direccion = direccion;
            CantidadVotantes = cantidadVotantes;
            SubCoordinadores = subCoordinadores;
            SubCoordinadoresId = subCoordinadoresId;
        }

        public DirigentesMultiplicadores(DirigentesMultiplicadoresId id, Cedula cedula, NumeroTelefono numeroTelefono, string nombre, string apellido, bool activo, Direccion direccion, CantidadVotos cantidadVotantes, SubCoordinadores subCoordinadores)
        {
            Id = id;
            Nombre = nombre;
            Apellido = apellido;
            Cedula = cedula;
            NumeroTelefono = numeroTelefono;
            Activo = activo;
            Direccion = direccion;
            CantidadVotantes = cantidadVotantes;
            SubCoordinadores = subCoordinadores;
           
        }
        public DirigentesMultiplicadoresId Id { get; set; }
        public string Nombre { get; set; } = string.Empty;
        public string Apellido { get; set; } = string.Empty;
        public string NombreCompleto => $"{Nombre} {Apellido}";
        public CantidadVotos CantidadVotantes { get; set; }
        public Cedula Cedula { get; private set; }
        public NumeroTelefono NumeroTelefono { get; private set; }
        public Direccion Direccion { get; set; }
        public bool Activo { get; private set; }
        public ICollection<Grupos> Grupos { get; set; }
        public ICollection<Votante> Votantes { get; set; }
        public VotantesDirigentes VotantesDirigentes { get; set; }
        public SubCoordinadoresId SubCoordinadoresId { get; set; } 
        public SubCoordinadores SubCoordinadores {  get; set; } 

        public static DirigentesMultiplicadores Update(DirigentesMultiplicadoresId id, Cedula cedula, NumeroTelefono numeroTelefono, string nombre, string apellido, bool activo, Direccion direccion, CantidadVotos cantidadVotantes, SubCoordinadores subCoordinadores,SubCoordinadoresId subCoordinadoresId)
        {
            return new DirigentesMultiplicadores(id,cedula,numeroTelefono,nombre,apellido,activo,direccion,cantidadVotantes,subCoordinadoresId,subCoordinadores);
        }

    }
}
