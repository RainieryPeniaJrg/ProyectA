using BE_ProyectoA.Core.Domain.Entities.Coordinadores;
using BE_ProyectoA.Core.Domain.Entities.CoordinadorGeneral;
using BE_ProyectoA.Core.Domain.Entities.Director;
using BE_ProyectoA.Core.Domain.Entities.DirigenteMultiplicador;
using BE_ProyectoA.Core.Domain.Entities.GruposEntity;
using BE_ProyectoA.Core.Domain.Entities.Votantes;
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
     
     
        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default); 

       

    }
}
