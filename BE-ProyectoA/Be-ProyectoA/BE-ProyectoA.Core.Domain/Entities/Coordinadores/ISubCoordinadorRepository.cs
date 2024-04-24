using BE_ProyectoA.Core.Domain.Entities.DirigenteMultiplicador;
using BE_ProyectoA.Core.Domain.Inferfaces;

namespace BE_ProyectoA.Core.Domain.Entities.Coordinadores
{
    public interface ISubCoordinadorRepository : IRepository<SubCoordinadores>
    {
        Task<List<SubCoordinadores>> GetAllSubCoordinadores(CancellationToken cancellationToken = default);
    }
}
