using System.ComponentModel.DataAnnotations;

namespace BE_ProyectoA.Core.Application.DTOs.Request.Account
{
    public class CreateAccountDTO : LoginDTO
    {
        [Required]
        public string Nombre { get; set; } = string.Empty;

        [Required, Compare(nameof(Password))]
   
        public string ConfirmPassword { get; set; } = string.Empty;
        [Required]
        public string Role { get; set; } = string.Empty;
    }
}
