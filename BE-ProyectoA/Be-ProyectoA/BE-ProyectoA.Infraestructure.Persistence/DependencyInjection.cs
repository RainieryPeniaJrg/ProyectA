using BE.MovieApp.Core.Application.Data;
using BE.MovieApp.Core.Domain.Movies;
using BE.MovieApp.Core.Domain.Primitivies;
using BE.MovieApp.Infraestructure.Persistence.persistence;
using BE.MovieApp.Infraestructure.Persistence.persistence.Repositories;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using BE.MovieApp.Core.Domain.Actors;
using BE.MovieApp.Core.Domain.ActorCharacter;
using BE.MovieApp.Core.Domain.Comments;
using BE.MovieApp.Core.Domain.MovieCast;
namespace BE.MovieApp.Infraestructure.Persistence
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

            services.AddScoped<IMovieRepository, MovieRepository>();
            services.AddScoped<IActorRepository, ActorRepository>();
            services.AddScoped<IActorCharacterRepository, ActorCharacterRepository>();
            services.AddScoped<ICommentRepository, CommentRepository>();
            services.AddScoped<IMovieCastRepository, MovieCastRepository>();

            return services;
        }
    }
}
