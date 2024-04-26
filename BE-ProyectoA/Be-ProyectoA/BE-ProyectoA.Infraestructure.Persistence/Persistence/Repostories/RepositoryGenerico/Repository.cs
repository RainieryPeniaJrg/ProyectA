using BE_ProyectoA.Core.Domain.Inferfaces;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Linq.Expressions;
using System.Threading;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace BE_ProyectoA.Infraestructure.Persistence.Persistence.Repostories.Repository
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly ApplicationDbContext _context;

        public Repository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task AddAsync(T entity, CancellationToken cancellationToken = default) =>
            await _context.Set<T>().AddAsync(entity, cancellationToken);

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
            await _context.Set<T>().Where(predicate).AsQueryable().AsNoTracking().ToListAsync(cancellationToken);
    }
}

    
