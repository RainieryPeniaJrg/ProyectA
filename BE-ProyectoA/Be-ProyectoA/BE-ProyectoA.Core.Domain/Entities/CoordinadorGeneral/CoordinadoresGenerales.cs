using BE_ProyectoA.Core.Domain.Entities.Coordinadores;
using BE_ProyectoA.Core.Domain.Entities.GruposEntity;
using BE_ProyectoA.Core.Domain.Primitivies;
using BE_ProyectoA.Core.Domain.ValueObjects;
using System.Collections.Generic;
using System;
using BE_ProyectoA.Core.Domain.Entities.Votantes;


namespace BE_ProyectoA.Core.Domain.Entities.CoordinadorGeneral
{
    public sealed class CoordinadoresGenerales  : AggregateRoot
    {

       public CoordinadoresGenerales() { }
       public CoordinadoresGenerales(CoordinadoresGeneralesId id, string nombre,string apellido, Cedula cedula, NumeroTelefono numeroTelefono, bool activo,Direccion direccion, CantidadVotos cantidadVotantes)    
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

        public CoordinadoresGenerales(CoordinadoresGeneralesId id, string nombre, string apellido, Cedula cedula, NumeroTelefono numeroTelefono, bool activo, Direccion direccion)
        {
            Id = id;
            Nombre = nombre;
            Apellido = apellido;
            Cedula = cedula;
            NumeroTelefono = numeroTelefono;
            Activo = activo;
            Direccion = direccion;
          
        }

        public CoordinadoresGenerales(CoordinadoresGeneralesId id, string nombre, string apellido, Cedula cedula, NumeroTelefono numeroTelefono, bool activo, Direccion direccion, CantidadVotos cantidadVotantes, ICollection<Grupos> grupos, ICollection<SubCoordinadores> subCoordinadores)
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
        }
        public CoordinadoresGeneralesId Id { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public Cedula Cedula { get; set; }
        public NumeroTelefono NumeroTelefono { get; set; }
        public Direccion Direccion { get; set; }
        public CantidadVotos CantidadVotantes { get; set; }
        public bool Activo { get; set; }
        public ICollection<Grupos> Grupos { get; set; }
        public ICollection<SubCoordinadores> SubCoordinadores { get; set; }
        public ICollection<Votante> Votantes { get; set; }
        public string NombreCompleto => $"{Nombre} {Apellido}";
   
  

        public static CoordinadoresGenerales? UpdateWithRelationShip(Guid id,string nombre,string apellido,Cedula cedula,NumeroTelefono numeroTelefono,Direccion direccion,ICollection<Grupos> grupos, ICollection<SubCoordinadores> subCoordinadores,bool activo, CantidadVotos cantidadVotantes)
        {
            return new CoordinadoresGenerales(new CoordinadoresGeneralesId(id), nombre, apellido, cedula, numeroTelefono, activo, direccion, cantidadVotantes, grupos, subCoordinadores);
        }

        public static CoordinadoresGenerales? UpdateWithOutRelationShip(Guid id, string nombre, string apellido, Cedula cedula, NumeroTelefono numeroTelefono, Direccion direccion, bool activo)
        {
            return new CoordinadoresGenerales(new CoordinadoresGeneralesId(id), nombre, apellido, cedula, numeroTelefono, activo, direccion);
        }

    }
}
