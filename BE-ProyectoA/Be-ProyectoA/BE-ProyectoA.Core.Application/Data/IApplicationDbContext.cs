using BE_ProyectoA.Core.Domain.Entities.Coordinadores;
using BE_ProyectoA.Core.Domain.Entities.CoordinadorGeneral;
using BE_ProyectoA.Core.Domain.Entities.Director;
using BE_ProyectoA.Core.Domain.Entities.DirigenteMultiplicador;
using BE_ProyectoA.Core.Domain.Entities.GruposEntity;
using BE_ProyectoA.Core.Domain.Entities.Votantes;
using BE_ProyectoA.Core.Domain.Entities.Votantes.VotantesCoordinadorGeneral;
using BE_ProyectoA.Core.Domain.Entities.Votantes.VotantesDirector;
using BE_ProyectoA.Core.Domain.Entities.Votantes.VotantesDirigentesEntity;
using BE_ProyectoA.Core.Domain.Entities.Votantes.VotantesSubCoordinadores;
using Microsoft.EntityFrameworkCore;

namespace BE_ProyectoA.Core.Application.Data
{
    public interface IApplicationDbContext
    {
        DbSet<SubCoordinadores> SubCoordinadores { get; set; }
        DbSet<CoordinadoresGenerales> CoordinadoresGenerales { get; set; }
        DbSet<Directores> Directores { get; set; }
        DbSet<DirigentesMultiplicadores> DirigentesMultiplicadores { get; set; }
        DbSet<Grupos> Grupos { get; set; }
        DbSet<Votante> Votantes { get; set; }
        DbSet<VotantesCoordinadoresGenerales> VotantesCoordinadores { get; set; }
        DbSet<VotantesDirectores> VotantesDirectors { get; set; }
        DbSet<VotantesDirigentes> VotantesDirigentes { get; set; }
        DbSet<VotantesSubCoordinador> VotantesSubCoordinadores { get; set; }
     
        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default); 

       

    }
}
