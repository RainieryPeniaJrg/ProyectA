using BE_ProyectoA.Core.Domain.Entities.GruposEntity;
using BE_ProyectoA.Core.Domain.Entities.Votantes;
using BE_ProyectoA.Core.Domain.Entities.Votantes.VotantesCoordinadorGeneral;
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
    }
}
