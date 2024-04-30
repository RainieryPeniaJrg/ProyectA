using BE_ProyectoA.Core.Domain.Entities.Votantes;
using BE_ProyectoA.Core.Domain.Entities.Votantes.VotantesCoordinadorGeneral;
using BE_ProyectoA.Infraestructure.Persistence.Persistence.Repostories.RepositoryGenerico;

namespace BE_ProyectoA.Infraestructure.Persistence.Persistence.Repostories.Repositories
{
    public class VotanteCoordiandorRepository : Repository<VotantesCoordinadoresGenerales>, IVotanteCoordinadorRepository
    {
        public VotanteCoordiandorRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}
