﻿using BE_ProyectoA.Core.Domain.Inferfaces;

namespace BE_ProyectoA.Core.Domain.Entities.Votantes.VotantesCoordinadorGeneral
{
    public interface IVotanteCoordinadorRepository : IRepository<VotantesCoordinadoresGenerales>
    {
        Task<IReadOnlyList<VotantesCoordinadoresGenerales>> GetAllVotantesCoordinador(CancellationToken cancellationToken);
    }
}
