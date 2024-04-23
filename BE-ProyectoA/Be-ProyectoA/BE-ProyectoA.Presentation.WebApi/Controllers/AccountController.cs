using BE_ProyectoA.Core.Application.Dtos.Users;
using BE_ProyectoA.Core.Application.Features.Usuarios.Authenticated.Commands;
using MediatR;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BE_ProyectoA.Presentation.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ApiController
    {
        private readonly ISender _mediator;

        public AccountController(ISender mediator)
        {
            _mediator = mediator;
        }
        [HttpPost("authenticate")]
         public async Task<IActionResult> AuthenticateAsync(AuthenticationRequest request)
        {
            var command = new AuthenticatedCommand
            {
                Email = request.Email,
                Password = request.Password,
                IpAdress = GenerateIpAddress()
            };

            var response = await _mediator.Send(command);

            return Ok(response);
        }

        [HttpPost("register")]
        public async Task<IActionResult> RegisterAsync(RegisterRequest request)
        {

            return Ok();
        }

        private string GenerateIpAddress()
        {
            if (Request.Headers.TryGetValue("X-Forwarded-For", out Microsoft.Extensions.Primitives.StringValues value))
                return value;

            else 
                return HttpContext.Connection.RemoteIpAddress.MapToIPv4().ToString();
        }

    }
}
