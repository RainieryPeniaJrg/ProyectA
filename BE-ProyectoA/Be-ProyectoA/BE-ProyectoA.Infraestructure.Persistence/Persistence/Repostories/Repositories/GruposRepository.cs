using BE_ProyectoA.Core.Domain.Entities.GruposEntity;
using BE_ProyectoA.Infraestructure.Persistence.Persistence.Repostories.RepositoryGenerico;
using Microsoft.EntityFrameworkCore;

namespace BE_ProyectoA.Infraestructure.Persistence.Persistence.Repostories.Repositories
{
    public class GruposRepository : Repository<Grupos>, IGruposRepository
    {
        private readonly ApplicationDbContext _context;
        public GruposRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<IReadOnlyList<Grupos>> GetAllGrupos(CancellationToken cancellationToken)
        {
            return await _context.Grupos
                .Include(g => g.DirigentesMultiplicadores)
                .Include(g => g.CoordinadorGeneral)
                .Include(g => g.SubCoordinadores)
                .ToListAsync(cancellationToken);
        }
    }
}
