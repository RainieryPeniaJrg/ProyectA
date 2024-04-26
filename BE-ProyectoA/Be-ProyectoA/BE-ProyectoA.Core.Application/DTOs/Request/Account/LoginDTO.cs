using System.ComponentModel.DataAnnotations;

namespace BE_ProyectoA.Core.Application.DTOs.Request.Account
{
    public class LoginDTO
    {
        [EmailAddress, Required]
        [RegularExpression("[^@ \\t\\r\\n]+@[^@ \\t\\r\\n]+\\.[^@ \\t\\r\\n]+",
            ErrorMessage = "Su Email no es valido, ingrese un correo electronico valido como ...@gmail,@hotmail")]
        [Display(Name = "Email Address")]
        public string Email { get; set; } = string.Empty;

        [Required]
        //[RegularExpression("^(?=.*?[a-z])(?=.*?[A-Z])(?=.*?[0-9])(?=.*?[@#$%^&+=]).{8,}$",
    //ErrorMessage = "Su contraseña debe contener al menos una letra minúscula, una letra mayúscula, un dígito numérico y un carácter especial.")]
        public string Password { get; set; } = string.Empty;
    }
}
