namespace BE_ProyectoA.Core.Domain.Inferfaces
{
    public interface IRepository<T> where T : class
    {
        Task AddAsync(T entity, CancellationToken cancellationToken = default);
        void Delete(T entity);
        void Update2(T entity, bool detachEntity = true);
        void Update(T entity);
        Task<bool> ExistsAsync(object id, CancellationToken cancellationToken = default);
        Task<T?> GetByIdAsync(object id, CancellationToken cancellationToken = default);
        Task<T?> GetByIdAsync2(object id, CancellationToken cancellationToken = default);
        Task<List<T>> GetAll(CancellationToken cancellationToken = default);
        Task<List<T>> GetBy(Func<T, bool> predicate, CancellationToken cancellationToken = default);
        Task<bool> ExecuteInTransaction(Func<Task<bool>> operation, CancellationToken cancellationToken = default);
     
    }
}
