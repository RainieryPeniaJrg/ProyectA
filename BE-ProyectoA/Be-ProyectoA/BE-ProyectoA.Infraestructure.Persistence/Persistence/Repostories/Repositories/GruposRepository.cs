using BE_ProyectoA.Core.Domain.Entities.GruposEntity;
using BE_ProyectoA.Core.Domain.Entities.Votantes;
using BE_ProyectoA.Infraestructure.Persistence.Persistence.Repostories.Repository;
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

        //public async Task<List<Grupos>> GetAllGrupos(CancellationToken cancellationToken = default)
        //{
        //    return await _context.Set<Grupos>()
        //        .Include(g=>g.CoordinadoresGenerales)
        //        .Include(g=>g.SubCoordinadores)
        //        .Include(g=>g.DirigentesMultiplicadores).ToListAsync();
        //}
    }
}
