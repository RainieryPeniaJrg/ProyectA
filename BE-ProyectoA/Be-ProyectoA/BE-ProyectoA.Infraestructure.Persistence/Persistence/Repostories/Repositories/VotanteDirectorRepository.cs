using BE_ProyectoA.Core.Domain.Entities.Director;
using BE_ProyectoA.Core.Domain.Entities.Votantes;
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

        public async Task<VotantesDirectores?> GetByIdWithMembers(Guid id, CancellationToken cancellationToken)
        {
            var votanteDirigente = await _context.VotantesDirectors
                .Include(vc => vc.Director)
                .Include(vc => vc.Votante)
                .FirstOrDefaultAsync(vc => vc.VotanteId == new VotanteId(id), cancellationToken);

            return votanteDirigente;
        }

        public async Task<IReadOnlyList<VotantesDirectores>> GetByMemberId(Guid id, CancellationToken cancellationToken)
        {
            var votantesIds = await _context.VotantesDirectors
                .Where(vc => vc.DirectorId == new DirectoresId(id))
                .Select(vc => vc.VotanteId)
                .ToListAsync(cancellationToken);

            var votantes = await _context.VotantesDirectors
                .Include(v => v.Director)
                .Include(v => v.Votante)
                .Where(v => votantesIds.Contains(v.VotanteId))
                .ToListAsync(cancellationToken);

            return votantes;
        }
    }
}
