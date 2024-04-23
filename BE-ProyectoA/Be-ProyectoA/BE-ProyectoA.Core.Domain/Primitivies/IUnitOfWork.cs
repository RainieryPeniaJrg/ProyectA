namespace BE_ProyectoA.Core.Domain.Primitivies
{
    public interface IUnitOfWork
    {
        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
    }
}
