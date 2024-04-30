using BE_ProyectoA.Core.Domain.Entities.Coordinadores;
using BE_ProyectoA.Core.Domain.Entities.CoordinadorGeneral;
using BE_ProyectoA.Core.Domain.Entities.DirigenteMultiplicador;
using BE_ProyectoA.Core.Domain.Inferfaces;
using System.Threading.Tasks;

namespace BE_ProyectoA.Core.Domain.Entities.Votantes
{
    public interface IVotanteRepository : IRepository<Votante>
    {
        Task<IEnumerable<Votante>> GetAllWithMembers(CancellationToken cancellation= default);

        Task<bool> ExistsByCoordinadorGeneralAsync(CoordinadoresGeneralesId coordinadorGeneralId, string nombre, string apellido, CancellationToken cancellationToken);
        Task<bool> ExistsBySubCoordinadorAsync(SubCoordinadoresId subCoordinadorId, string nombre, string apellido, CancellationToken cancellationToken);
        Task<bool> ExistsByDirigenteAsync(DirigentesMultiplicadoresId dirigenteId, string nombre, string apellido, CancellationToken cancellationToken);
    }
}
