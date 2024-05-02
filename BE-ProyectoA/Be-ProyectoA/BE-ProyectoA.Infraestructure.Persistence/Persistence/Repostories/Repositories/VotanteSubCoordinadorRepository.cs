using BE_ProyectoA.Core.Domain.Entities.Votantes.VotantesDirigentesEntity;
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
    }
}
