using BE_ProyectoA.Core.Application.Data;
using BE_ProyectoA.Core.Domain.Entities.Coordinadores;
using BE_ProyectoA.Core.Domain.Entities.DirigenteMultiplicador;
using BE_ProyectoA.Infraestructure.Persistence.Persistence.Repostories.RepositoryGenerico;
using Microsoft.EntityFrameworkCore;

namespace BE_ProyectoA.Infraestructure.Persistence.Persistence.Repostories.Repositories
{
    public class SubCoordinadoresRepository : Repository<SubCoordinadores>, ISubCoordinadorRepository
    {
        private readonly ApplicationDbContext _context;
        public SubCoordinadoresRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<List<SubCoordinadores>> GetAllSubCoordinadores(CancellationToken cancellationToken = default)
        {
            return await _context.Set<SubCoordinadores>().Include(sc => sc.Coordinadores).ToListAsync(cancellationToken);
        }
    }
}
