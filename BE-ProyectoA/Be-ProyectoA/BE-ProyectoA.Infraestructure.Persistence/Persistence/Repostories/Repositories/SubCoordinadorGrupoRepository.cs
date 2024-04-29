using BE_ProyectoA.Core.Domain.Entities.Coordinadores;
using BE_ProyectoA.Core.Domain.Entities.GruposEntity.GrupoSubCoordinador;
using BE_ProyectoA.Infraestructure.Persistence.Persistence.Repostories.RepositoryGenerico;

namespace BE_ProyectoA.Infraestructure.Persistence.Persistence.Repostories.Repositories
{
    public class SubCoordinadorGrupoRepository : Repository<GrupoSubCoordinador>, IGrupoSubCoordinadorRepository
    {
        public SubCoordinadorGrupoRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}
