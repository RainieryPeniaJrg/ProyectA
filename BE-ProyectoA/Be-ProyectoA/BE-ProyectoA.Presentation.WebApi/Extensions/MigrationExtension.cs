using Bet_NetBanking.Infraestructure.Persistence.Persistense;
using Microsoft.EntityFrameworkCore;

namespace Presentation.BE_NetBanking.Api.Extensions
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
