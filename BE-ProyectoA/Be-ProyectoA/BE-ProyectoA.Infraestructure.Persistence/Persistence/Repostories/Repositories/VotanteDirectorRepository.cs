using BE_ProyectoA.Core.Domain.Entities.Votantes.VotantesDirector;
using BE_ProyectoA.Infraestructure.Persistence.Persistence.Repostories.RepositoryGenerico;

namespace BE_ProyectoA.Infraestructure.Persistence.Persistence.Repostories.Repositories
{
    public class VotanteDirectorRepository : Repository<VotantesDirectores>, IVotantesDirectorRepository
    {
        public VotanteDirectorRepository(ApplicationDbContext context) : base(context)
        {

        }
    }
}
