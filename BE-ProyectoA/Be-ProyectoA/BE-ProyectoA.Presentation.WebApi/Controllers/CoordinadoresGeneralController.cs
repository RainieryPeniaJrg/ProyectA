using BE_ProyectoA.Core.Application.CoordinadoresGeneralesFeatures.Commands.Create;
using BE_ProyectoA.Core.Application.CoordinadoresGeneralesFeatures.Commands.Delete;
using BE_ProyectoA.Core.Application.CoordinadoresGeneralesFeatures.Commands.Update;
using BE_ProyectoA.Core.Application.CoordinadoresGeneralesFeatures.Query.GetAll;
using BE_ProyectoA.Core.Application.VotantesFeatures.VotantesCoordinador.Queries.GetAll;
using BE_ProyectoA.Core.Application.VotantesFeatures.VotantesCoordinador.Queries.GetById;
using BE_ProyectoA.Core.Application.VotantesFeatures.VotantesCoordinador.Queries.GetByMember;
using ErrorOr;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace BE_ProyectoA.Presentation.WebApi.Controllers
{
    //[Authorize(Roles = "Admin,CoordinadorGeneral")]
    public class CoordinadoresGeneralController(ISender mediator) : ApiControllercs
    {
        private readonly ISender _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));

        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            var coordinadorResult = await _mediator.Send(new GetAllCoordinadorGeneralQuery());

            return coordinadorResult.Match(
                coordinador => Ok(coordinador),
                errors => Problem(errors)
            );
        }

        [HttpGet("GetAllVotantesByMemberId/{Id}")]
        public async Task<IActionResult> GetAllVotantesCoordinadoresByMemberId(Guid Id)
        {
            var coordinadorResult = await _mediator.Send(new GetByMemberIdVotantesCoordinadorQuery(Id));

            return coordinadorResult.Match(
                Votante => Ok(Votante),
                errors => Problem(errors)
            );
        }
        [HttpGet("GetVotantesByIdWithMember/{Id}")]
        public async Task<IActionResult> GetAllVotantesCoordinadoresByIdWithMember(Guid Id)
        {
            var coordinadorResult = await _mediator.Send(new GetByIdVotantesCoordinadorQuery(Id));

            return coordinadorResult.Match(
                Votante => Ok(Votante),
                errors => Problem(errors)
            );
        }

        [HttpGet("GetAllVotantes")]
        public async Task<IActionResult> GetAllVotantesCoordinadores()
        {
            var coordinadorResult = await _mediator.Send(new GetAllVotantesCoordinadorQuery());

            return coordinadorResult.Match(
                Votante => Ok(Votante),
                errors => Problem(errors)
            );
        }


        [HttpPost("Create")]
        public async Task<IActionResult> Create([FromBody] CreateCoordinadorCommand command)
        {
            var createResult = await _mediator.Send(command);
            return createResult.Match(
                coordinadorId => Ok(coordinadorId),
                errors => Problem(errors)
            );
        }

        [HttpPut("Update/{id}")]
        public async Task<IActionResult> Update(Guid id, [FromBody] UpdateCoordinadorGeneralCommand command)
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
                coordinadorId => NoContent(),
                errors => Problem(errors)
            );
        }


        [HttpDelete("Delete/{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var deleteResult = await _mediator.Send(new DeleteCoordinadorCommand(id));

            return deleteResult.Match(
                coordinadorId => NoContent(),
                errors => Problem(errors)
            );
        }

     
    }
}
