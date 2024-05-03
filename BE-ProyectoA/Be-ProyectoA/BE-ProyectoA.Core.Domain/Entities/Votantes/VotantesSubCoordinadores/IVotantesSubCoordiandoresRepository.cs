using BE_ProyectoA.Core.Domain.Inferfaces;

namespace BE_ProyectoA.Core.Domain.Entities.Votantes.VotantesSubCoordinadores
{
    public interface IVotantesSubCoordiandoresRepository : IRepository<VotantesSubCoordinador>
    {

        Task<IReadOnlyList<VotantesSubCoordinador>> GetAllVotantesSubCoordinador(CancellationToken cancellationToken);
        Task<VotantesSubCoordinador?> GetByIdWithMembers(Guid subCoordinadorId, CancellationToken cancellationToken);
        Task<IReadOnlyList<VotantesSubCoordinador>> GetByMemberId(Guid id, CancellationToken cancellation);
    }
}
