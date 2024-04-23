using BE_ProyectoA.Infraestructure.Persistence.Persistence;
using Microsoft.EntityFrameworkCore;

namespace BE_ProyectoA.Presentation.WebApi.Extensions
{
    public static class MigrationExtension
    {
        public static void ApplyMigration(this WebApplication app)
        {
            using var scope = app.Services.CreateScope();
            var dbContext = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
            dbContext.Database.Migrate();
        }
    }
}
