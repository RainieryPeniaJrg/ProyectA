using BE_ProyectoA.Core.Domain.Entities.DirigenteMultiplicador;
using BE_ProyectoA.Infraestructure.Persistence.Persistence.Repostories.Repository;

namespace BE_ProyectoA.Infraestructure.Persistence.Persistence.Repostories.Repositories
{
    public class DirigentesMultiplicadoresRepository(ApplicationDbContext context) : Repository<DirigentesMultiplicadores>(context), IDirigenteMultiplicadorRepository
    {
    }
}
