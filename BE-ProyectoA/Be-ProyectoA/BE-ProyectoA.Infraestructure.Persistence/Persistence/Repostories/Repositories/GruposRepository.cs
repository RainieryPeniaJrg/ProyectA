using BE_ProyectoA.Core.Domain.Entities.GruposEntity;
using BE_ProyectoA.Core.Domain.Entities.Votantes;
using BE_ProyectoA.Infraestructure.Persistence.Persistence.Repostories.Repository;

namespace BE_ProyectoA.Infraestructure.Persistence.Persistence.Repostories.Repositories
{
    public class GruposRepository : Repository<Grupos>, IGruposRepository
    {
        public GruposRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}
