using BE_ProyectoA.Core.Domain.Entities.Coordinadores;
using BE_ProyectoA.Core.Domain.Entities.CoordinadorGeneral;
using BE_ProyectoA.Core.Domain.Entities.Votantes;
using BE_ProyectoA.Core.Domain.Entities.Votantes.VotantesSubCoordinadores;
using BE_ProyectoA.Infraestructure.Persistence.Persistence.Repostories.RepositoryGenerico;
using Microsoft.EntityFrameworkCore;

namespace BE_ProyectoA.Infraestructure.Persistence.Persistence.Repostories.Repositories
{
    public class VotanteSubCoordinadorRepository : Repository<VotantesSubCoordinador>, IVotantesSubCoordiandoresRepository
    {
        private readonly ApplicationDbContext _context;
        public VotanteSubCoordinadorRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<IReadOnlyList<VotantesSubCoordinador>> GetAllVotantesSubCoordinador(CancellationToken cancellationToken)
        {
            return await _context.VotantesSubCoordinadores
                .Include(vc => vc.SubCoordinador)
                .Include(vc => vc.Votante)
                .Where(vc => vc.VotanteId != null && vc.SubCoordinadorId != null)
                .ToListAsync(cancellationToken);
        }

        public async Task<VotantesSubCoordinador?> GetByIdWithMembers(Guid id, CancellationToken cancellationToken)
        {
            var votanteSubCoordinador = await _context.VotantesSubCoordinadores
                .Include(vc => vc.SubCoordinador)
                .Include(vc => vc.Votante)
                .FirstOrDefaultAsync(vc => vc.VotanteId == new VotanteId(id), cancellationToken);

            return votanteSubCoordinador;
        }

        public async Task<IReadOnlyList<VotantesSubCoordinador>> GetByMemberId(Guid id, CancellationToken cancellationToken)
        {
            var votantesIds = await _context.VotantesSubCoordinadores
                .Where(vc => vc.SubCoordinadorId == new SubCoordinadoresId(id))
                .Select(vc => vc.VotanteId)
                .ToListAsync(cancellationToken);

            var votantes = await _context.VotantesSubCoordinadores
                .Include(v => v.SubCoordinador)
                .Include (v => v.Votante)
                .Where(v => votantesIds.Contains(v.VotanteId))
                .ToListAsync(cancellationToken);

            return votantes;
        }
    }
}
