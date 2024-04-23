using System.Linq.Expressions;

namespace BE_ProyectoA.Core.Domain.Inferfaces
{
    public interface IRepository<TEntity> where TEntity : class
    {
        Task<TEntity?> GetEntityAsync(Expression<Func<TEntity, bool>>? filter = null, bool tracked = true);
        Task<List<TEntity>> GetEntitiesAsync(Expression<Func<TEntity, bool>>? filter = null);
        Task<bool> ExistsAsync(Expression<Func<TEntity, bool>> filter);
        Task SaveAsync(TEntity entity);
        Task SaveAsync(TEntity[] entities);
        Task UpdateAsync(TEntity entity);
        Task UpdateAsync(TEntity[] entities);
        Task RemoveAsync(TEntity entity);
        Task RemoveAsync(TEntity[] entities);
  
        Task SaveChangesAsync();

    }
}
