using BE_ProyectoA.Core.Application.Data;
using BE_ProyectoA.Core.Domain.Entities.Coordinadores;
using BE_ProyectoA.Infraestructure.Persistence.Persistence.Repostories.Repository;

namespace BE_ProyectoA.Infraestructure.Persistence.Persistence.Repostories.Repositories
{
    public class SubCoordinadoresRepository : Repository<SubCoordinadores>, ISubCoordinadorRepository
    {
        private readonly IApplicationDbContext _context;
        public SubCoordinadoresRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }

     
    }
}
