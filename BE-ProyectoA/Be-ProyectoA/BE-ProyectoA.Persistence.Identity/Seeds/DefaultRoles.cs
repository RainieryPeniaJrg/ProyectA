using BE_ProyectoA.Core.Application.Enums;
using BE_ProyectoA.Persistence.Identity.Model;
using Microsoft.AspNetCore.Identity;

namespace BE_ProyectoA.Persistence.Identity.Seeds
{
    public static class DefaultRoles
    {
        public static async Task SeedAsync(UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            await roleManager.CreateAsync(new IdentityRole(Roles.administrador.ToString()));
            await roleManager.CreateAsync(new IdentityRole(Roles.dirigente.ToString()));
            await roleManager.CreateAsync(new IdentityRole(Roles.coordinador.ToString()));
            await roleManager.CreateAsync(new IdentityRole(Roles.subcoordinador.ToString()));
        }
    }
}
