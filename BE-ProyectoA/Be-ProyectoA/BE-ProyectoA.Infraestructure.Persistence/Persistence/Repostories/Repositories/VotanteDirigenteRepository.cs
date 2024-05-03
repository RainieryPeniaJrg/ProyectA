using BE_ProyectoA.Core.Domain.Entities.Votantes.VotantesDirector;
using BE_ProyectoA.Core.Domain.Entities.Votantes.VotantesDirigentesEntity;
using BE_ProyectoA.Infraestructure.Persistence.Persistence.Repostories.RepositoryGenerico;
using Microsoft.EntityFrameworkCore;

namespace BE_ProyectoA.Infraestructure.Persistence.Persistence.Repostories.Repositories
{
    public class VotanteDirigenteRepository : Repository<VotantesDirigentes>, IVotantesDirigenteRepository
    {
        private readonly ApplicationDbContext _context;
        public VotanteDirigenteRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<IReadOnlyList<VotantesDirigentes>> GetAllVotantesDirigente(CancellationToken cancellationToken)
        {
            return await _context.VotantesDirigentes
                .Include(vc => vc.DirigenteId)
                .Include(vc => vc.Votante)
                .Where(vc => vc.VotanteId != null && vc.DirigenteId != null)
                .ToListAsync(cancellationToken);
        }
    }
}
