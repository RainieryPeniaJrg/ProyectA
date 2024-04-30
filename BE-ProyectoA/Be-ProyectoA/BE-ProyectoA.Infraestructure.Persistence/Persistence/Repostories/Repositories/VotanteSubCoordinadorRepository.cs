using BE_ProyectoA.Core.Domain.Entities.Votantes.VotantesCoordinadorGeneral;
using BE_ProyectoA.Core.Domain.Entities.Votantes.VotantesSubCoordinadores;
using BE_ProyectoA.Infraestructure.Persistence.Persistence.Repostories.RepositoryGenerico;

namespace BE_ProyectoA.Infraestructure.Persistence.Persistence.Repostories.Repositories
{
    public class VotanteSubCoordinadorRepository : Repository<VotantesSubCoordinador>, IVotantesSubCoordiandoresRepository
    {
        public VotanteSubCoordinadorRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}
