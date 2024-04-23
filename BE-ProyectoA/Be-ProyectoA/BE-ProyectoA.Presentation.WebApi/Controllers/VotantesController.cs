using BE_ProyectoA.Core.Application.Director.Commands.Create;
using BE_ProyectoA.Core.Application.Votantes.Commands.Create;
using BE_ProyectoA.Core.Application.Votantes.Commands.Update;
using BE_ProyectoA.Core.Domain.Entities.Votantes;
using ErrorOr;
using MediatR;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BE_ProyectoA.Presentation.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VotantesController (ISender mediator) : ApiControllercs
    {

        private readonly ISender _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
       
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<VotantesController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<VotantesController>
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateVotanteCommand command )
        {
            var createResult = await _mediator.Send(command);
            return createResult.Match(
                VotanteId => Ok(VotanteId),
                errors => Problem(errors)
            );
        }
        [HttpPut("{id}")]
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


        // DELETE api/<VotantesController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
