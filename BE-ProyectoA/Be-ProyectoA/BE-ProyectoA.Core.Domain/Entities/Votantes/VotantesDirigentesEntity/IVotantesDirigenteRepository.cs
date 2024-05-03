using BE_ProyectoA.Core.Domain.Inferfaces;

namespace BE_ProyectoA.Core.Domain.Entities.Votantes.VotantesDirigentesEntity
{
    public interface IVotantesDirigenteRepository : IRepository<VotantesDirigentes>
    {
       Task<IReadOnlyList<VotantesDirigentes>> GetByMemberId(Guid id, CancellationToken cancellationToken);
       Task<VotantesDirigentes?> GetByIdWithMembers(Guid id, CancellationToken cancellationToken);
       Task<IReadOnlyList<VotantesDirigentes>> GetAllVotantesDirigente(CancellationToken cancellationToken);
    }
}
