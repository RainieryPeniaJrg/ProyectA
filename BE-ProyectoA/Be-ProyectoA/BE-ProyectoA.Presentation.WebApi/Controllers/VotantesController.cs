using BE_ProyectoA.Core.Application.VotantesFeatures.Commands.Create;
using BE_ProyectoA.Core.Application.VotantesFeatures.Commands.Delete;
using BE_ProyectoA.Core.Application.VotantesFeatures.Commands.Update;
using BE_ProyectoA.Core.Application.VotantesFeatures.Querys.GetAll;
using BE_ProyectoA.Core.Application.VotantesFeatures.Querys.GetByCedulaQuery;
using BE_ProyectoA.Core.Application.VotantesFeatures.Querys.GetById;
using BE_ProyectoA.Core.Application.VotantesFeatures.VotantesCoordinador.Queries.GetAll;
using BE_ProyectoA.Core.Application.VotantesFeatures.VotantesDirector.Queries.GetAll;
using BE_ProyectoA.Core.Application.VotantesFeatures.VotantesDirigente.Queries.GetAll;
using BE_ProyectoA.Core.Application.VotantesFeatures.VotantesSubCoordinadorFeatures.Queries.GetAll;
using ErrorOr;
using MediatR;
using Microsoft.AspNetCore.Mvc;


namespace BE_ProyectoA.Presentation.WebApi.Controllers
{
    //[Authorize(Roles = "Admin,CoordinadorGeneral,SubCoordinador,Dirigente")]
    [Route("api/[controller]")]
    [ApiController]
    public class VotantesController (ISender mediator) : ApiControllercs
    {

        private readonly ISender _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));

        [HttpGet ("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            var votanteResult = await _mediator.Send(new GetAllVotanteQuery());

            return votanteResult.Match(
                Votante => Ok(Votante),
                errors => Problem(errors)
            );
        }


        [HttpGet("Coordinadores/GetAll")]
        public async Task<IActionResult> GetAllVotantesCoordinadores()
        {
            var votanteResult = await _mediator.Send(new GetAllVotantesCoordinadorQuery());

            return votanteResult.Match(
                Votante => Ok(Votante),
                errors => Problem(errors)
            );
        }

        [HttpGet("Director/GetAll")]
        public async Task<IActionResult> GetAllVotantesDirector()
        {
            var votanteResult = await _mediator.Send(new GetAllVotantesDirectorQuery());

            return votanteResult.Match(
                Votante => Ok(Votante),
                errors => Problem(errors)
            );
        }


        [HttpGet("SubCoordinadores/GetAll")]
        public async Task<IActionResult> GetAllVotantesSubCoordinadores()
        {
            var votanteResult = await _mediator.Send(new GetAllVotantesSubCoordinadoresQuery());

            return votanteResult.Match(
                Votante => Ok(Votante),
                errors => Problem(errors)
            );
        }


        [HttpGet("Dirigente/GetAll")]
        public async Task<IActionResult> GetAllVotantesDirigente()
        {
            var votanteResult = await _mediator.Send(new GetAllVotantesDirigenteQuery());

            return votanteResult.Match(
                Votante => Ok(Votante),
                errors => Problem(errors)
            );
        }

        // POST api/<VotantesController>
        [HttpPost ("Create")]
        public async Task<IActionResult> Create([FromBody] CreateVotanteCommand command )
        {
            var createResult = await _mediator.Send(command);
            return createResult.Match(
                VotanteId => Ok(VotanteId),
                errors => Problem(errors)
            );
        }
        [HttpPut("Update/{id}")]
        public async Task<IActionResult> Update(Guid id, [FromBody] UpdateVotanteCommand command)
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
            var deleteResult = await _mediator.Send(new DeleteVotanteCommand (id));

            return deleteResult.Match(
                votanteId => NoContent(),
                errors => Problem(errors)
            );
        }

        [HttpGet("ById/{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var votanteResult = await _mediator.Send(new GetByIdVotantesQuery (id));

            return votanteResult.Match(
                votante => Ok(votante),
                errors => Problem(errors)
            );
        }


        [HttpGet("ByCedula/{cedula}")]
        public async Task<IActionResult> GetByCedula(string cedula)
        {
            var votanteResult = await _mediator.Send(new GetByCedulaQuery (cedula));

            return votanteResult.Match(
                votante => Ok(votante),
                errors => Problem(errors)
            );
        }
    }
}
