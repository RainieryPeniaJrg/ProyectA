using BE.MovieApp.Core.Application.Data;
using BE.MovieApp.Core.Domain.ActorCharacter;
using BE.MovieApp.Core.Domain.Actors;
using BE.MovieApp.Core.Domain.Comments;
using BE.MovieApp.Core.Domain.MovieCast;
using BE.MovieApp.Core.Domain.Movies;
using BE.MovieApp.Core.Domain.Primitivies;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace BE.MovieApp.Infraestructure.Persistence.persistence
{
    public class ApplicationDbContext : DbContext,IApplicationDbContext,IUnitOfWork
    {
        private readonly IPublisher _publisher;

        public ApplicationDbContext(IPublisher publisher, DbContextOptions options): base(options)
        {
            _publisher = publisher ?? throw new ArgumentNullException(nameof(publisher));
          
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseLazyLoadingProxies(true).LogTo(s => System.Console.WriteLine(s));

           
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly);
        }
        public DbSet<Movies> Movies { get; set; }
        public DbSet<Actor> Actors { get; set; }
        public DbSet<Comments> Comments { get; set; }
        public DbSet<ActorCharacter> ActorCharacters { get; set; }
        public DbSet<MovieCast> MoviesCasts { get; set; }

        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
        {
            var events = ChangeTracker.Entries<AggregateRoot>()
                .Select(e => e.Entity)
                .Where(e => e.GetDomainEvents().Any())
                .SelectMany(e => e.GetDomainEvents());

            var result = await base.SaveChangesAsync(cancellationToken);

            foreach (var domainEvents in events)
            {
                await _publisher.Publish(domainEvents, cancellationToken);
            }

            return result;

        }
    }
}
