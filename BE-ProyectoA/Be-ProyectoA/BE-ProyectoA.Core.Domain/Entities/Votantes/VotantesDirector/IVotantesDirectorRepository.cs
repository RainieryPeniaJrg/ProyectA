using BE_ProyectoA.Core.Domain.Inferfaces;

namespace BE_ProyectoA.Core.Domain.Entities.Votantes.VotantesDirector
{
    public interface IVotantesDirectorRepository : IRepository<VotantesDirectores>
    {
        Task<IReadOnlyList<VotantesDirectores>> GetByMemberId(Guid id, CancellationToken cancellationToken);
        Task<VotantesDirectores?> GetByIdWithMembers(Guid id, CancellationToken cancellationToken);
        Task<IReadOnlyList<VotantesDirectores>> GetAllVotantesDirector(CancellationToken cancellationToken);

    }    
}
