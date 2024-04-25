using BE_ProyectoA.Core.Domain.Entities.DirigenteMultiplicador;
using BE_ProyectoA.Core.Domain.Inferfaces;

namespace BE_ProyectoA.Core.Domain.Entities.GruposEntity
{
    public interface IGruposRepository : IRepository<Grupos>
    {
        Task<IReadOnlyList<Grupos>> GetAllGrupos(CancellationToken token);


    }
}
