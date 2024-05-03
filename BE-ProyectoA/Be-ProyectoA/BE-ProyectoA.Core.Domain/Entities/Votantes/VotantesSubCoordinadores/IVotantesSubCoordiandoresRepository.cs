using BE_ProyectoA.Core.Domain.Inferfaces;

namespace BE_ProyectoA.Core.Domain.Entities.Votantes.VotantesSubCoordinadores
{
    public interface IVotantesSubCoordiandoresRepository : IRepository<VotantesSubCoordinador>
    {

        Task<IReadOnlyList<VotantesSubCoordinador>> GetAllVotantesSubCoordinador(CancellationToken cancellationToken);
    }
}
