using BE_ProyectoA.Core.Domain.Entities.DirigenteMultiplicador;
using BE_ProyectoA.Core.Domain.Entities.Votantes;
using BE_ProyectoA.Infraestructure.Persistence.Persistence.Repostories.Repository;
using Microsoft.EntityFrameworkCore;

namespace BE_ProyectoA.Infraestructure.Persistence.Persistence.Repostories.Repositories
{
    public class DirigentesMultiplicadoresRepository : Repository<DirigentesMultiplicadores>, IDirigenteMultiplicadorRepository
    {
        private readonly ApplicationDbContext _context;
        public DirigentesMultiplicadoresRepository(ApplicationDbContext context) : base(context)
        { 
            _context = context;
        }

        public async Task<List<DirigentesMultiplicadores>> GetAllDirigenteMultiplicadores(CancellationToken cancellationToken = default)
        {
            return await _context.Set<DirigentesMultiplicadores>()
                                  .Include(dm => dm.SubCoordinadores)
                                  .ToListAsync(cancellationToken);
        }
    }
}
