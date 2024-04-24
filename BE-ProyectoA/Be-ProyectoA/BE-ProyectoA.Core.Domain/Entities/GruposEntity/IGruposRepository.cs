using BE_ProyectoA.Core.Domain.Entities.DirigenteMultiplicador;
using BE_ProyectoA.Core.Domain.Inferfaces;

namespace BE_ProyectoA.Core.Domain.Entities.GruposEntity
{
    public interface IGruposRepository : IRepository<Grupos>
    {
        Task<List<Grupos>> GetAllGrupos(CancellationToken cancellationToken = default);
    }
}
