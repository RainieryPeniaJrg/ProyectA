using BE_ProyectoA.Core.Domain.Inferfaces;
using Microsoft.EntityFrameworkCore;

namespace BE_ProyectoA.Infraestructure.Persistence.Persistence.Repostories.RepositoryGenerico
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly ApplicationDbContext _context;

        public Repository(ApplicationDbContext context)
        {
            _context = context;
        }
        public void Update2(T entity, bool detachEntity = true)
        {
           
            if (detachEntity)
            {
                _context.Entry(entity).State = EntityState.Detached;
            }
            _context.Set<T>().Update(entity);
        }
        public async Task AddAsync(T entity, CancellationToken cancellationToken = default)
        {
            if (entity != null)
            {
                await _context.Set<T>().AddAsync(entity!, cancellationToken);

                _context.Entry(entity).State = EntityState.Added;
            }
            else
            {
                await _context.Set<T>().AddAsync(entity!, cancellationToken);
            }
        }
        public void Delete(T entity) => _context.Set<T>().Remove(entity);

        public void Update(T entity) => _context.Set<T>().Update(entity);

        public async Task<bool> ExistsAsync(object id, CancellationToken cancellationToken = default)
        {
            var keyValues = new[] { id };
            var entity = await _context.Set<T>().FindAsync(keyValues, cancellationToken);
            return entity != null;
        }

        public async Task<T?> GetByIdAsync(object id, CancellationToken cancellationToken = default)
        {
            var keyValues = new[] { id };
            var entity = await _context.Set<T>().FindAsync(keyValues, cancellationToken);

            if (entity != null)
            {
                _context.Entry(entity).State = EntityState.Detached;
            }

            return entity;
        }

        public async Task<List<T>> GetAll(CancellationToken cancellationToken = default) =>
            await _context.Set<T>().AsNoTracking().ToListAsync(cancellationToken);

        public async Task<List<T>> GetBy(Func<T, bool> predicate, CancellationToken cancellationToken = default) =>
             _context.Set<T>().AsNoTracking().Where(predicate).ToList();

        public async Task<bool> ExecuteInTransaction(Func<Task<bool>> operation, CancellationToken cancellationToken = default)
        {
            await using var transaction = await _context.Database.BeginTransactionAsync(cancellationToken);
            try
            {
                var success = await operation();
                if (success)
                {
                    await transaction.CommitAsync(cancellationToken);
                    return true;
                }
                else
                {
                    await transaction.RollbackAsync(cancellationToken);
                    return false;
                }
            }
            catch (Exception)
            {
                await transaction.RollbackAsync(cancellationToken);
                throw;
            }
        }

        public async Task<T?> GetByIdAsync2(object id, CancellationToken cancellationToken = default)
        {
            var keyValues = new object[] { id };
            var entity = await _context.Set<T>().FindAsync(keyValues, cancellationToken);

            return entity;
        }
    }
}