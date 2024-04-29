using BE_ProyectoA.Core.Domain.Entities.Coordinadores;
using BE_ProyectoA.Core.Domain.Entities.Votantes;
using BE_ProyectoA.Infraestructure.Persistence.Persistence.Repostories.RepositoryGenerico;
using Microsoft.EntityFrameworkCore;

namespace BE_ProyectoA.Infraestructure.Persistence.Persistence.Repostories.Repositories
{
    public class VotanteRepository : Repository<Votante>, IVotanteRepository
    {
        private readonly ApplicationDbContext _context;
        public VotanteRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;

        }

        public async Task<IEnumerable<Votante>> GetAllWithMembers(CancellationToken cancellation)
        {
            var votantesConMiembros = await _context.Votantes
                .Include(v => v.Director)
                .Include(v => v.SubCoordinador)
                .Include(v => v.CoordinadorGeneral)
                .Include(v => v.Dirigente)
                .Where(v =>
                    v.DirectorId != null ||
                    v.SubCoordinadorId != null ||
                    v.CoordinadorGeneralId != null ||
                    v.DirigenteId != null
                )
                .ToListAsync();

            return votantesConMiembros;
        }

        // Si necesitas agregar métodos específicos para el repositorio de votantes, puedes hacerlo aquí
    }
}

