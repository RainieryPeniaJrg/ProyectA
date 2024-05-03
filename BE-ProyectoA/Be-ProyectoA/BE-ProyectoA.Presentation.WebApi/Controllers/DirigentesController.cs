using BE_ProyectoA.Core.Application.DirigentesFeatures.Commands.Create;
using BE_ProyectoA.Core.Application.DirigentesFeatures.Commands.Delete;
using BE_ProyectoA.Core.Application.DirigentesFeatures.Commands.Update;
using BE_ProyectoA.Core.Application.DirigentesFeatures.Querys.GetAll;
using BE_ProyectoA.Core.Application.VotantesFeatures.VotantesDirigente.Queries.GetAll;
using BE_ProyectoA.Core.Application.VotantesFeatures.VotantesDirigente.Queries.GetById;
using BE_ProyectoA.Core.Application.VotantesFeatures.VotantesDirigente.Queries.GetByMemberId;
using ErrorOr;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BE_ProyectoA.Presentation.WebApi.Controllers
{
    //[Authorize(Roles = "Admin,SubCoordinador,Dirigente")]
    [Route("api/[controller]")]
    [ApiController]
    public class DirigentesController(ISender mediator) : ApiControllercs
    {
        private readonly ISender _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));

  



        [HttpGet("GetVotantesByIdWithMember{Id}")]
        public async Task<IActionResult> GetAllVotantesDirigenteByIdWithMember(Guid Id)
        {
            var DirigenteResult = await _mediator.Send(new GetByIdVotantesDirigenteQuery(Id));

            return DirigenteResult.Match(
                Votante => Ok(Votante),
                errors => Problem(errors)
            );
        }

        [HttpGet("GetAllVotantesByMemberId{Id}")]
        public async Task<IActionResult> GetAllVotantesDiriegenteByMemberId(Guid Id)
        {
            var DirigenteResult = await _mediator.Send(new GetByMemberIdVotantesDirigenteQuery(Id));

            return DirigenteResult.Match(
                Votante => Ok(Votante),
                errors => Problem(errors)
            );
        }


        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAllVotantesDirigente()
        {
            var DirigenteResult = await _mediator.Send(new GetAllVotantesDirigenteQuery());

            return DirigenteResult.Match(
                Votante => Ok(Votante),
                errors => Problem(errors)
            );
        }


        [HttpPost("Create")]
        public async Task<IActionResult> Create([FromBody] CreateDirigentesCommand command)
        {
            var createResult = await _mediator.Send(command);
            return createResult.Match(
                DirigenteId => Ok(DirigenteId),
                errors => Problem(errors)
            );
        }

        [HttpPut("Update/{id}")]
        public async Task<IActionResult> Update(Guid id, [FromBody] UpdateDirigenteCommand command)
        {
            if (command.Id != id)
            {
                List<Error> errors = new()
                {
                    Error.Validation("Dirigente.UpdateInvalid", "The request Id does not match with the url Id.")
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
            var deleteResult = await _mediator.Send(new DeleteDirigenteCommand(id));

            return deleteResult.Match(
                dirigenteId => NoContent(),
                errors => Problem(errors)
            );
        }

    }
}
