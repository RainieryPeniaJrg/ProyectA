using BE_ProyectoA.Core.Application.Data;
using BE_ProyectoA.Core.Domain.Primitivies;
using BE_ProyectoA.Infraestructure.Persistence.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
namespace BE_ProyectoA.Infraestructure.Persistence
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfraEstructure(this IServiceCollection services,
            IConfiguration configuration)
        {
            services.AddPersistence(configuration);
            return services;
        }

        public static IServiceCollection AddPersistence(this IServiceCollection services, IConfiguration configuration)
        {

            services.AddDbContext<ApplicationDbContext>
                (
                         options =>
                         options.UseSqlServer(configuration.GetConnectionString("Database")));

            services.AddScoped<IApplicationDbContext>(sp => sp.GetRequiredService<ApplicationDbContext>());

            services.AddScoped<IUnitOfWork>(sp => sp.GetRequiredService<ApplicationDbContext>());


            return services;
        }
    }
}
