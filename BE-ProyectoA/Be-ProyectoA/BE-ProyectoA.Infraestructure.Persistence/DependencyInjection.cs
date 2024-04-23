using BE_ProyectoA.Core.Application.Data;
using BE_ProyectoA.Core.Domain.Entities.Coordinadores;
using BE_ProyectoA.Core.Domain.Entities.CoordinadorGeneral;
using BE_ProyectoA.Core.Domain.Entities.Director;
using BE_ProyectoA.Core.Domain.Entities.DirigenteMultiplicador;
using BE_ProyectoA.Core.Domain.Entities.GruposEntity;
using BE_ProyectoA.Core.Domain.Entities.Votantes;
using BE_ProyectoA.Core.Domain.Inferfaces;
using BE_ProyectoA.Core.Domain.Primitivies;
using BE_ProyectoA.Infraestructure.Persistence.Persistence;
using BE_ProyectoA.Infraestructure.Persistence.Persistence.Repostories.Repositories;
using BE_ProyectoA.Infraestructure.Persistence.Persistence.Repostories.Repository;
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
                         options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));

            services.AddScoped<IApplicationDbContext>(sp => sp.GetRequiredService<ApplicationDbContext>());

            services.AddScoped<IUnitOfWork>(sp => sp.GetRequiredService<ApplicationDbContext>());

            services.AddScoped<IDirigenteMultiplicadorRepository,DirigentesMultiplicadoresRepository>();

            services.AddScoped<ISubCoordinadorRepository, SubCoordinadoresRepository>();

            services.AddScoped<ICoordinadorGeneralRepository, CoordinadoresGeneralesRepository>();

            services.AddScoped<IVotanteRepository, VotanteRepository>();

            services.AddScoped<IDirectoresRepository, DirectorRepository>();

            services.AddScoped<IGruposRepository, GruposRepository>();

            return services;
        }
    }
}
