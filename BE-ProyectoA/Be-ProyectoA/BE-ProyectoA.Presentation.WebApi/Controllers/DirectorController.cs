using BE_ProyectoA.Core.Application.Director.Commands.Create;
using BE_ProyectoA.Core.Application.Director.Commands.Delete;
using BE_ProyectoA.Core.Domain.Entities.Director;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BE_ProyectoA.Presentation.WebApi.Controllers
{
    [Authorize(Roles = "Admin")]
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

        //[HttpGet("{id}")]
        //public async Task<IActionResult> GetById(Guid id)
        //{
        //    var customerResult = await _mediator.Send(new GetCustomerByIdQuery(id));

        //    return customerResult.Match(
        //        customer => Ok(customer),
        //        errors => Problem(errors)
        //    );
        //}
        //[HttpPost]
        //public async Task<IActionResult> Create([FromBody] CreateCustomerCommand command)
        //{
        //    var createResult = await _mediator.Send(command);

        //    return createResult.Match(
        //        customerId => Ok(customerId),
        //        errors => Problem(errors)
        //    );
        //}

        //[HttpPut("{id}")]
        //public async Task<IActionResult> Update(Guid id, [FromBody] UpdateCustomerCommand command)
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
        //        customerId => NoContent(),
        //        errors => Problem(errors)
        //    );
        //}

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
