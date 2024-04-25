﻿using System.ComponentModel.DataAnnotations;

namespace BE_ProyectoA.Core.Application.DTOs.Request.Account
{
    public class CreateAccountDTO : LoginDTO
    {
        [Required]
        public string Nombre { get; set; } = string.Empty;

        [Required]
        public string Apellido { get; set; } = string.Empty;
        [Required]
        public string Cedula { get; set; } = string.Empty;
        [Required]
        public string NumeroTelefono { get; set; } = string.Empty;
        [Required]
        public string Provincia { get; set; } = string.Empty;
        [Required]
        public string Sector { get; set; } = string.Empty;
        [Required]
        public int casaElectoral {get; set; }
        [Required]
        public int CantidadVotantes { get; set; }
        [Required]
        public bool Activo { get; set; }

        public Guid SubCoordinadorId { get; set; }

        public Guid CoordinadorGeneralId { get; set; }

        public Guid DirigenteId { get; set; }

        [Required, Compare(nameof(Password))]
        public string ConfirmPassword { get; set; } = string.Empty;
        [Required]
        public string Role { get; set; } = string.Empty;
    }
}
