using Microsoft.AspNetCore.Identity;

namespace BE_ProyectoA.Core.Domain.Entities.Authentication
{
    public class ApplicationUser : IdentityUser
    {
        public string? Nombre { get; set; }
    }
}
