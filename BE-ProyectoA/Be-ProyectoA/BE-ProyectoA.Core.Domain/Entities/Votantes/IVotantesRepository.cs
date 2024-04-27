using BE_ProyectoA.Core.Domain.Inferfaces;
using System.Threading.Tasks;

namespace BE_ProyectoA.Core.Domain.Entities.Votantes
{
    public interface IVotanteRepository : IRepository<Votante>
    {
        Task<IEnumerable<Votante>> GetAllWithMembers(CancellationToken cancellation= default);
    }
}
