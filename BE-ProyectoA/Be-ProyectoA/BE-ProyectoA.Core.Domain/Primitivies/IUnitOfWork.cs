namespace BE.MovieApp.Core.Domain.Primitivies
{
    public interface IUnitOfWork
    {
        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
    }
}
