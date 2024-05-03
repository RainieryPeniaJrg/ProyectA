using BE_ProyectoA.Core.Domain.Entities.Coordinadores;
using BE_ProyectoA.Core.Domain.Entities.CoordinadorGeneral;
using BE_ProyectoA.Core.Domain.Entities.Votantes;
using BE_ProyectoA.Core.Domain.Entities.Votantes.VotantesCoordinadorGeneral;
using BE_ProyectoA.Core.Domain.Entities.Votantes.VotantesSubCoordinadores;
using BE_ProyectoA.Infraestructure.Persistence.Persistence.Repostories.RepositoryGenerico;
using Microsoft.EntityFrameworkCore;

namespace BE_ProyectoA.Infraestructure.Persistence.Persistence.Repostories.Repositories
{
    public class VotanteCoordiandorRepository : Repository<VotantesCoordinadoresGenerales>, IVotanteCoordinadorRepository
    {

        private readonly ApplicationDbContext _context;
        public VotanteCoordiandorRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<IReadOnlyList<VotantesCoordinadoresGenerales>> GetAllVotantesCoordinador(CancellationToken cancellationToken)
        {
            return await _context.VotantesCoordinadores
                .Include(vc => vc.Coordinador)
                .Include(vc => vc.Votante)
                .Where(vc => vc.VotanteId != null && vc.CoordinadorId != null)
                .ToListAsync(cancellationToken);
        }

        public async Task<VotantesCoordinadoresGenerales?> GetByIdWithMembers(Guid id, CancellationToken cancellationToken)
        {
            var votanteDirigente = await _context.VotantesCoordinadores
                .Include(vc => vc.Coordinador)
                .Include(vc => vc.Votante)
                .FirstOrDefaultAsync(vc => vc.VotanteId == new VotanteId(id), cancellationToken);

            return votanteDirigente;
        }

        public async Task<IReadOnlyList<VotantesCoordinadoresGenerales>> GetByMemberId(Guid id, CancellationToken cancellationToken)
        {
            var votantesIds = await _context.VotantesCoordinadores
                .Where(vc => vc.CoordinadorId == new CoordinadoresGeneralesId(id))
                .Select(vc => vc.VotanteId)
                .ToListAsync(cancellationToken);

            var votantes = await _context.VotantesCoordinadores
                .Include(v => v.Coordinador)
                .Include(v => v.Votante)
                .Where(v => votantesIds.Contains(v.VotanteId))
                .ToListAsync(cancellationToken);

            return votantes;
        }
    }
}
