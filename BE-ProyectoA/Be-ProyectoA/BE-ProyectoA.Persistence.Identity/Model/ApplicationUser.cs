using Microsoft.AspNetCore.Identity;

namespace BE_ProyectoA.Persistence.Identity.Model
{
    public class ApplicationUser : IdentityUser
    {
        public string? Nombre { get; set; }
        public string? Apellido { get; set; }

    }
}
