using BE_ProyectoA.Core.Domain.Entities.Votantes.VotantesCoordinadorGeneral;
using BE_ProyectoA.Core.Domain.Entities.Votantes.VotantesDirector;
using BE_ProyectoA.Infraestructure.Persistence.Persistence.Repostories.RepositoryGenerico;
using Microsoft.EntityFrameworkCore;

namespace BE_ProyectoA.Infraestructure.Persistence.Persistence.Repostories.Repositories
{
    public class VotanteDirectorRepository : Repository<VotantesDirectores>, IVotantesDirectorRepository
    {
        private readonly ApplicationDbContext _context; 
        public VotanteDirectorRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }
        public async Task<IReadOnlyList<VotantesDirectores>> GetAllVotantesDirector(CancellationToken cancellationToken)
        {
            return await _context.VotantesDirectors
                .Include(vc => vc.Director)
                .Include(vc => vc.Votante)
                .Where(vc => vc.VotanteId != null && vc.DirectorId != null)
                .ToListAsync(cancellationToken);
        }
    }
}
