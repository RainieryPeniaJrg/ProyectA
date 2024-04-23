using BE_ProyectoA.Core.Domain.Inferfaces;

namespace BE_ProyectoA.Core.Domain.Entities.Director
{
    public interface IDirectoresRepository : IRepository<Directores>
    {
        Task<bool> ExistsAsync(DirectoresId id);
    }
}
