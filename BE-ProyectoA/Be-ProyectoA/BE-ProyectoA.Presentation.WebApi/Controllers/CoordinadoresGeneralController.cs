using BE_ProyectoA.Core.Application.CoordinadoresGeneralesFeatures.Commands.Create;
using BE_ProyectoA.Core.Application.Votantes.Commands.Create;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace BE_ProyectoA.Presentation.WebApi.Controllers
{
    public class CoordinadoresGeneralController(ISender mediator) : ApiControllercs
    {
        private readonly ISender _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));

        //[HttpGet("GetAll")]
        //public async Task<IActionResult> GetAll()
        //{
        //    var votanteResult = await _mediator.Send(new GetAllVotanteQuery());

        //    return votanteResult.Match(
        //        Votante => Ok(Votante),
        //        errors => Problem(errors)
        //    );
        //}


     
        [HttpPost("Create")]
        public async Task<IActionResult> Create([FromBody] CreateCoordinadorCommand command)
        {
            var createResult = await _mediator.Send(command);
            return createResult.Match(
                coordinadorId => Ok(coordinadorId),
                errors => Problem(errors)
            );
        }
        //[HttpPut("Update/{id}")]
        //public async Task<IActionResult> Update(Guid id, [FromBody] UpdateVotanteCommand command)
        //{
        //    if (command.Id != id)
        //    {
        //        List<Error> errors = new()
        //        {
        //            Error.Validation("Customer.UpdateInvalid", "The request Id does not match with the url Id.")
        //        };
        //        return Problem(errors);
        //    }

        //    var updateResult = await _mediator.Send(command);

        //    return updateResult.Match(
        //        VotanteId => NoContent(),
        //        errors => Problem(errors)
        //    );
        //}


        //[HttpDelete("Delete/{id}")]
        //public async Task<IActionResult> Delete(Guid id)
        //{
        //    var deleteResult = await _mediator.Send(new DeleteVotanteCommand(id));

        //    return deleteResult.Match(
        //        votanteId => NoContent(),
        //        errors => Problem(errors)
        //    );
        //}

        //[HttpGet("ById/{id}")]
        //public async Task<IActionResult> GetById(Guid id)
        //{
        //    var votanteResult = await _mediator.Send(new GetByIdVotantesQuery(id));

        //    return votanteResult.Match(
        //        votante => Ok(votante),
        //        errors => Problem(errors)
        //    );
        //}


        //[HttpGet("ByCedula/{cedula}")]
        //public async Task<IActionResult> GetByCedula(string cedula)
        //{
        //    var votanteResult = await _mediator.Send(new GetByCedulaQuery(cedula));

        //    return votanteResult.Match(
        //        votante => Ok(votante),
        //        errors => Problem(errors)
        //    );
        //}
    }
}
