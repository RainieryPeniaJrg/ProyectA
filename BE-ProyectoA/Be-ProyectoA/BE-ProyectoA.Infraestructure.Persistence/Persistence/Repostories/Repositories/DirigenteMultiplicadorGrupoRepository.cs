using BE_ProyectoA.Core.Domain.Entities.GruposEntity.GrupoDirigente;
using BE_ProyectoA.Infraestructure.Persistence.Persistence.Repostories.RepositoryGenerico;

namespace BE_ProyectoA.Infraestructure.Persistence.Persistence.Repostories.Repositories
{
    public class DirigenteMultiplicadorGrupoRepository : Repository<GrupoDirigente>, IGrupoDirigenteRepository
    {
        public DirigenteMultiplicadorGrupoRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}
