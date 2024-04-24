using BE_ProyectoA.Core.Domain.Inferfaces;

namespace BE_ProyectoA.Core.Domain.Entities.DirigenteMultiplicador
{
    public interface IDirigenteMultiplicadorRepository : IRepository<DirigentesMultiplicadores>
    {
        Task<List<DirigentesMultiplicadores>> GetAllDirigenteMultiplicadores(CancellationToken cancellationToken = default);
    }
}
