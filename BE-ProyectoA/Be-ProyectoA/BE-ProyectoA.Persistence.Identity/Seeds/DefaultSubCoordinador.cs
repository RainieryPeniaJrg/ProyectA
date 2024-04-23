using BE_ProyectoA.Core.Application.Enums;
using BE_ProyectoA.Persistence.Identity.Model;
using Microsoft.AspNetCore.Identity;

namespace BE_ProyectoA.Persistence.Identity.Seeds
{
    public static class DefaultSubCoordinador
    { 
         public static async Task SeedAsync(UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager)
    {
        var defaultUser = new ApplicationUser
        {
            UserName = "userCliente",
            Email = "userDirigente@mail.com",
            EmailConfirmed = true,
            Nombre = "Alexis",
            Apellido = "De leon ",
            PhoneNumberConfirmed = true,

        };

        if (userManager.Users.All(u => u.Id != defaultUser.Id))
        {
            var user = await userManager.FindByEmailAsync(defaultUser.Email);
            if (user != null)
            {
                await userManager.CreateAsync(defaultUser, "123password");

                await userManager.AddToRoleAsync(defaultUser, Roles.subcoordinador.ToString());
            }

        }
    }
}

}
