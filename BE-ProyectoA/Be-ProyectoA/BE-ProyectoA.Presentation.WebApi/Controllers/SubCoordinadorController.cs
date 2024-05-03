using BE_ProyectoA.Core.Application.SubCoordinadorFeatures.Commands.Create;
using BE_ProyectoA.Core.Application.SubCoordinadorFeatures.Commands.Delete;
using BE_ProyectoA.Core.Application.SubCoordinadorFeatures.Commands.Update;
using BE_ProyectoA.Core.Application.SubCoordinadorFeatures.Querys;
using BE_ProyectoA.Core.Application.VotantesFeatures.VotantesSubCoordinadorFeatures.Queries.GetAll;
using BE_ProyectoA.Core.Application.VotantesFeatures.VotantesSubCoordinadorFeatures.Queries.GetById;
using BE_ProyectoA.Core.Application.VotantesFeatures.VotantesSubCoordinadorFeatures.Queries.GetByMemberId;
using ErrorOr;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BE_ProyectoA.Presentation.WebApi.Controllers
{
    //[Authorize(Roles = "Admin,SubCoordinador,CoordinadorGeneral")]

    [Route("api/[controller]")]
    [ApiController]
    public class SubCoordinadorController(ISender mediator) : ApiControllercs
    {

        private readonly ISender _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));


        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            var votanteResult = await _mediator.Send(new GetAllSubCoordinadorQuery());

            return votanteResult.Match(
                Votante => Ok(Votante),
                errors => Problem(errors)
            );
        }



        [HttpPost("Create")]
        public async Task<IActionResult> Create([FromBody] CreateSubCoordinadorCommand command)
        {
            var createResult = await _mediator.Send(command);
            return createResult.Match(
                subCoordinadorId => Ok(subCoordinadorId),
                errors => Problem(errors)
            );
        }

        [HttpPut("Update/{id}")]
        public async Task<IActionResult> Update(Guid id, [FromBody] UpdateSubCoordinadorCommand command)
        {
            if (command.Id != id)
            {
                List<Error> errors = new()
                {
                    Error.Validation("Customer.UpdateInvalid", "The request Id does not match with the url Id.")
                };
                return Problem(errors);
            }

            var updateResult = await _mediator.Send(command);

            return updateResult.Match(
                VotanteId => NoContent(),
                errors => Problem(errors)
            );
        }


        [HttpDelete("Delete/{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var deleteResult = await _mediator.Send(new DeleteSubCoordinadorCommand(id));

            return deleteResult.Match(
                votanteId => NoContent(),
                errors => Problem(errors)
            );
        }

        [HttpGet("GetAllVotantes")]
        public async Task<IActionResult> GetAllVotantesSubCoordinadores()
        {
            var votanteResult = await _mediator.Send(new GetAllVotantesSubCoordinadoresQuery());

            return votanteResult.Match(
                Votante => Ok(Votante),
                errors => Problem(errors)
            );
        }


        [HttpGet("GetAllVotantesByMemberId/{Id}")]
        public async Task<IActionResult> GetAllVotantesSubCoordinadoresByMemberId(Guid Id)
        {
            var votanteResult = await _mediator.Send(new GetByMemberIdVotantesSubCoordinadorQuery(Id));

            return votanteResult.Match(
                Votante => Ok(Votante),
                errors => Problem(errors)
            );
        }


        [HttpGet("GetVotantesByIdWithMember/{Id}")]
        public async Task<IActionResult> GetAllVotantesSubCoordinadoresByIdWithMember(Guid Id)
        {
            var votanteResult = await _mediator.Send(new GetByIdVotantesSubCoordinadorQuery(Id));

            return votanteResult.Match(
                Votante => Ok(Votante),
                errors => Problem(errors)
            );
        }


    }
}
