using BE_ProyectoA.Core.Domain.Entities.Coordinadores;
using BE_ProyectoA.Core.Domain.Entities.DirigenteMultiplicador;
using BE_ProyectoA.Core.Domain.Entities.Votantes;
using BE_ProyectoA.Infraestructure.Persistence.Persistence.Repostories.Repository;

namespace BE_ProyectoA.Infraestructure.Persistence.Persistence.Repostories.Repositories
{
    public class SubCoordinadoresRepository : Repository<SubCoordinadores>, ISubCoordinadorRepository
    {
        public SubCoordinadoresRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}
