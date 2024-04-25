using BE_ProyectoA.Core.Application.DTOs.Request.Account;
using BE_ProyectoA.Core.Application.DTOs.Response;
using BE_ProyectoA.Core.Application.DTOs.Response.Account;
using BE_ProyectoA.Core.Application.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BE_ProyectoA.Presentation.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController (IAccount account) : ControllerBase
    {
        [HttpPost("identity/create")]
        public async Task<ActionResult<GeneralResponse>> CreateAccount(CreateAccountDTO model)
        {
            if(!ModelState.IsValid)
                return BadRequest("model cannot be null");

            return Ok(await account.CreateAccountAsync(model));
            
        }

        [HttpPost("identity/login")]
        public async Task<ActionResult<GeneralResponse>> LoginAccount(LoginDTO model)
        {
            if (!ModelState.IsValid)
                return BadRequest("Model cannor be null");
            return Ok(await account.LoginAccountAsync(model));
        }

        [HttpPost("identity/refresh-token")]
        public async Task<ActionResult<GeneralResponse>> RefreshToken(RefreshTokenDTO model)
        {
            if (!ModelState.IsValid)
                return BadRequest("Model cannor be null");
            return Ok(await account.RefreshTokenAsync(model));
        }

        [HttpGet("identity/role-list")]
        public async Task<ActionResult<IEnumerable<GetRoleDTO>>> GetRoles()
            => Ok(await account.GetRolesAsync());

        [HttpPost("/settings")]
        public async Task<IActionResult> CreateAdmin()
        {
            await account.CreateAdmin();
            return Ok();
        }

        [HttpGet("identity/users-with-role")]
        public async Task<ActionResult<IEnumerable<GetUsersWithRoleDTO>>> GetUserWithRoles()
          => Ok(await account.GetUsersWithRolesAsync());

        [HttpPost("identity/change-role")]
        public async Task<ActionResult<GeneralResponse>> ChangeUserRole(ChangeRoleRequestDTO model)=>
            Ok(await account.ChangeUserRoleAsync(model));


    }

}
