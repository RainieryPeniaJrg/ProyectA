using BE_ProyectoA.Core.Application.Enums;
using BE_ProyectoA.Persistence.Identity.Model;
using Microsoft.AspNetCore.Identity;

namespace BE_ProyectoA.Persistence.Identity.Seeds
{
    public static class DefaultAdminUser
    {
        public static async Task SeedAsync(UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            var defaultUser = new ApplicationUser
            {
                UserName = "userAdmin",
                Email = "userAdmin@mail.com",
                EmailConfirmed = true,
                Nombre = "Alexix",
                Apellido = "De Leon",
                PhoneNumberConfirmed = true,

            };

            if (userManager.Users.All(u => u.Id != defaultUser.Id))
            {
                var user = await userManager.FindByEmailAsync(defaultUser.Email);
                if (user != null)
                {
                    await userManager.CreateAsync(defaultUser, "123password");
                    await userManager.AddToRoleAsync(defaultUser, Roles.administrador.ToString());
                    await userManager.AddToRoleAsync(defaultUser, Roles.coordinador.ToString());
                    await userManager.AddToRoleAsync(defaultUser, Roles.subcoordinador.ToString());
                    await userManager.AddToRoleAsync(defaultUser, Roles.dirigente.ToString());
                   
                }
            }
        }
    }
}
