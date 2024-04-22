using BE_ProyectoA.Core.Application.Dtos.Users;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BE_ProyectoA.Presentation.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ApiController
    {
        [HttpPost("authenticate")]

        public async Task<IActionResult> AuthenticateAsync(AuthenticationRequest request)
        {

            return Ok();
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
