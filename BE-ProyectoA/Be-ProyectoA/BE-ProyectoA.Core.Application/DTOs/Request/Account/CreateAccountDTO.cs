using BE_ProyectoA.Core.Domain.ValueObjects;
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

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
   
        public bool Activo { get; set; }

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public Guid SubCoordinadorId { get; set; }

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public Guid CoordinadorGeneralId { get; set; }

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public Guid DirigenteId { get; set; }

        [Required, Compare(nameof(Password))]
        public string ConfirmPassword { get; set; } = string.Empty;
        [Required]
        public string Role { get; set; } = string.Empty;
    }
}
