using BE_ProyectoA.Core.Domain.Entities.DirigenteMultiplicador;
using BE_ProyectoA.Core.Domain.Entities.Votantes;
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
                .Include(vc => vc.Dirigente)
                .Include(vc => vc.Votante)
                .Where(vc => vc.VotanteId != null && vc.DirigenteId != null)
                .ToListAsync(cancellationToken);
        }

        public async Task<VotantesDirigentes?> GetByIdWithMembers(Guid id, CancellationToken cancellationToken)
        {
            var votanteDirigente = await _context.VotantesDirigentes
                .Include(vc => vc.Dirigente)
                .Include(vc => vc.Votante)
                .FirstOrDefaultAsync(vc => vc.VotanteId == new VotanteId(id), cancellationToken);

            return votanteDirigente;
        }

        public async Task<IReadOnlyList<VotantesDirigentes>> GetByMemberId(Guid id, CancellationToken cancellationToken)
        {
            var votantesIds = await _context.VotantesDirigentes
                .Where(vc => vc.DirigenteId == new DirigentesMultiplicadoresId(id))
                .Select(vc => vc.VotanteId)
                .ToListAsync(cancellationToken);

            var votantes = await _context.VotantesDirigentes
                .Include(v => v.Dirigente)
                .Include(v => v.Votante)
                .Where(v => votantesIds.Contains(v.VotanteId))
                .ToListAsync(cancellationToken);

            return votantes;
        }
    }
}
