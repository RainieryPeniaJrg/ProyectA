using BE_ProyectoA.Core.Application.Director.Commands.Create;
using BE_ProyectoA.Core.Application.Director.Commands.Delete;
using BE_ProyectoA.Core.Application.VotantesFeatures.VotantesDirector.Queries.GetAll;
using BE_ProyectoA.Core.Application.VotantesFeatures.VotantesDirector.Queries.GetById;
using BE_ProyectoA.Core.Application.VotantesFeatures.VotantesDirector.Queries.GetByMemberId;
using BE_ProyectoA.Core.Domain.Entities.Director;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BE_ProyectoA.Presentation.WebApi.Controllers
{
    [Authorize(Roles = "Director")]
    [Route("api/[controller]")]
    [ApiController]
    public class DirectorController(ISender mediator) : ApiControllercs
    {
        private readonly ISender _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] DirectorCreateCommand command)
        {
            var createResult = await _mediator.Send(command);
            return createResult.Match(
                DirectoresId => Ok(DirectoresId),
                errors => Problem(errors)
            );
        }

        [HttpGet("GetAllVotantes")]
        public async Task<IActionResult> GetAllVotantesDirector()
        {
            var votanteResult = await _mediator.Send(new GetAllVotantesDirectorQuery());

            return votanteResult.Match(
                Votante => Ok(Votante),
                errors => Problem(errors)
            );
        }
        [HttpGet("GetAllVotantesByMemberId/{Id}")]
        public async Task<IActionResult> GetAllVotantesDirectorByMemberId(Guid Id)
        {
            var votanteResult = await _mediator.Send(new GetByMemberIdVotantesDirectorQuery(Id));

            return votanteResult.Match(
                Votante => Ok(Votante),
                errors => Problem(errors)
            );
        }

        [HttpGet("GetVotantesByIdWithMember/{Id}")]
        public async Task<IActionResult> GetAllVotantesDirectorByIdWithMember(Guid Id)
        {
            var votanteResult = await _mediator.Send(new GetByIdVotantesDirectorQuery(Id));

            return votanteResult.Match(
                Votante => Ok(Votante),
                errors => Problem(errors)
            );
        }


        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var deleteResult = await _mediator.Send(new DeleteDirectorCommand(id));

            return deleteResult.Match(
                customerId => NoContent(),
                errors => Problem(errors)
            );
        }
    }
}
