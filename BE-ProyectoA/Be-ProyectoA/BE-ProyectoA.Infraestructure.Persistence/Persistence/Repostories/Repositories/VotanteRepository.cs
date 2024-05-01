using BE_ProyectoA.Core.Domain.Entities.Coordinadores;
using BE_ProyectoA.Core.Domain.Entities.CoordinadorGeneral;
using BE_ProyectoA.Core.Domain.Entities.Director;
using BE_ProyectoA.Core.Domain.Entities.DirigenteMultiplicador;
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

        public async Task<bool> ExistsByCoordinadorGeneralAsync(CoordinadoresGeneralesId coordinadorGeneralId, string nombre, string apellido, CancellationToken cancellationToken)
        {
            return await _context.Votantes.AnyAsync(v =>
                v.CoordinadorGeneralId == coordinadorGeneralId &&
                v.Nombre == nombre &&
                v.Apellido == apellido, cancellationToken);
        }

        public async Task<bool> ExistsBySubCoordinadorAsync(SubCoordinadoresId subCoordinadorId, string nombre, string apellido, CancellationToken cancellationToken)
        {
            return await _context.Votantes.AnyAsync(v =>
                v.SubCoordinadorId == subCoordinadorId &&
                v.Nombre == nombre &&
                v.Apellido == apellido, cancellationToken);
        }

        public async Task<bool> ExistsByDirigenteAsync(DirigentesMultiplicadoresId dirigenteId, string nombre, string apellido, CancellationToken cancellationToken)
        {
            return await _context.Votantes.AnyAsync(v =>
                v.DirigenteId == dirigenteId &&
                v.Nombre == nombre &&
                v.Apellido == apellido, cancellationToken);
        }


        public async Task<bool> ExistsByDirectorAsync(DirectoresId directorId, string nombre, string apellido, CancellationToken cancellationToken)
        {
            return await _context.Votantes.AnyAsync(v =>
             v.DirectorId == directorId &&
             v.Nombre == nombre &&
             v.Apellido == apellido, cancellationToken);
        }

        // Si necesitas agregar métodos específicos para el repositorio de votantes, puedes hacerlo aquí
    }
}

