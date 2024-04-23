using BE_ProyectoA.Core.Domain.Entities.DirigenteMultiplicador;
using BE_ProyectoA.Core.Domain.Entities.Votantes;
using BE_ProyectoA.Infraestructure.Persistence.Persistence.Repostories.Repository;

namespace BE_ProyectoA.Infraestructure.Persistence.Persistence.Repostories.Repositories
{
    public class DirigentesMultiplicadoresRepository : Repository<DirigentesMultiplicadores>, IDirigenteMultiplicadorRepository
    {
        public DirigentesMultiplicadoresRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}
