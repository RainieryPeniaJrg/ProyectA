using BE_ProyectoA.Persistence.Identity.Model;
using BE_ProyectoA.Persistence.Identity.Seeds;
using Microsoft.AspNetCore.Identity;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddPresentationn().AddInfraEstructure(builder.Configuration).AddApplication(

var app = builder.Build();


using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;

    try
    {
        var userManager = services.GetRequiredService<UserManager<ApplicationUser>>();
        var roleManager = services.GetRequiredService<RoleManager<IdentityRole>>();

        await DefaultRoles.SeedAsync(userManager, roleManager);
        await DefaultAdminUser.SeedAsync(userManager, roleManager);
        await DefaultDirigenteUser.SeedAsync(userManager, roleManager);
        await DefaultCoordinadorUser.SeedAsync(userManager, roleManager);
        await DefaultSubCoordinador.SeedAsync(userManager, roleManager);
    }
    catch (Exception ex)
    {
        throw;
    }
    app.Run();
}
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
    app.ApplyMigration();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
