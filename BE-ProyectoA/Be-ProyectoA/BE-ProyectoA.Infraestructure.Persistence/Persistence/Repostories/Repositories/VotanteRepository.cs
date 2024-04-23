using BE_ProyectoA.Core.Domain.Entities.Coordinadores;
using BE_ProyectoA.Core.Domain.Entities.Votantes;
using BE_ProyectoA.Infraestructure.Persistence.Persistence.Repostories.Repository;
using Microsoft.EntityFrameworkCore;

namespace BE_ProyectoA.Infraestructure.Persistence.Persistence.Repostories.Repositories
{
    public class VotanteRepository : Repository<Votante>, IVotanteRepository
    {
        public VotanteRepository(ApplicationDbContext context) : base(context)
        {
        }

        // Si necesitas agregar métodos específicos para el repositorio de votantes, puedes hacerlo aquí
    }
}

