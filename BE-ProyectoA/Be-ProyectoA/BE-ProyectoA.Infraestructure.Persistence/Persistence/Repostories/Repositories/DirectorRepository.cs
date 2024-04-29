using BE_ProyectoA.Core.Domain.Entities.CoordinadorGeneral;
using BE_ProyectoA.Core.Domain.Entities.Director;
using BE_ProyectoA.Infraestructure.Persistence.Persistence.Repostories.RepositoryGenerico;
using Microsoft.EntityFrameworkCore;

namespace BE_ProyectoA.Infraestructure.Persistence.Persistence.Repostories.Repositories
{
    public class DirectorRepository(ApplicationDbContext context) : Repository<Directores>(context), IDirectoresRepository
    {
       private readonly ApplicationDbContext applicationDbContext = context;
        public Task<bool> ExistsAsync(DirectoresId id) => applicationDbContext.Directores.AnyAsync(director=>director.Id == id);
       
    }
}
