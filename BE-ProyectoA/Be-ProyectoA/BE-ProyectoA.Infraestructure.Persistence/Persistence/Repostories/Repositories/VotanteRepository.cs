using BE_ProyectoA.Core.Domain.Entities.Coordinadores;
using BE_ProyectoA.Core.Domain.Entities.Votantes;
using BE_ProyectoA.Infraestructure.Persistence.Persistence.Repostories.Repository;

namespace BE_ProyectoA.Infraestructure.Persistence.Persistence.Repostories.Repositories
{
    internal class VotanteRepository(ApplicationDbContext context) : Repository<Votante>(context), IVotantesRepository
    {
    }
}
