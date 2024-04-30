using BE_ProyectoA.Core.Domain.Entities.Votantes.VotantesDirigentesEntity;
using BE_ProyectoA.Infraestructure.Persistence.Persistence.Repostories.RepositoryGenerico;

namespace BE_ProyectoA.Infraestructure.Persistence.Persistence.Repostories.Repositories
{
    public class VotanteDirigenteRepository : Repository<VotantesDirigentes>, IVotantesDirigenteRepository
    {
        public VotanteDirigenteRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}
