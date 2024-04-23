using BE_ProyectoA.Core.Domain.Entities.GruposEntity;
using BE_ProyectoA.Infraestructure.Persistence.Persistence.Repostories.Repository;

namespace BE_ProyectoA.Infraestructure.Persistence.Persistence.Repostories.Repositories
{
    public class GruposRepository(ApplicationDbContext context) : Repository<Grupos>(context), IGruposRepository
    {
    }
}
