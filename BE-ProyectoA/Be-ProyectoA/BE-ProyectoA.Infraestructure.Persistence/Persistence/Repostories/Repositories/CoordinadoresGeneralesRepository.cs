﻿using BE_ProyectoA.Core.Domain.Entities.CoordinadorGeneral;
using BE_ProyectoA.Infraestructure.Persistence.Persistence.Repostories.Repository;

namespace BE_ProyectoA.Infraestructure.Persistence.Persistence.Repostories.Repositories
{
    public class CoordinadoresGeneralesRepository(ApplicationDbContext context) : Repository<CoordinadoresGenerales>(context), ICoordinadorGeneralRepository
    {

    }
}
