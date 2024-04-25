using BE_ProyectoA.Core.Application.DTOs.Request.Account;
using BE_ProyectoA.Core.Application.DTOs.Response.Account;
using BE_ProyectoA.Core.Application.DTOs.Response;

namespace BE_ProyectoA.Core.Application.Services
{
    public interface IAccountServices
    {
        Task CreateAdmin();
        Task<GeneralResponse> CreateAccountAsync(CreateAccountDTO model);
        Task<LoginResponse> LoginAccountAsync(LoginDTO model);

        Task<GeneralResponse> CreateRoleAsync(CreateRoleDTO model);
        Task<LoginResponse> RefreshTokenAsync(RefreshTokenDTO model);
        Task<GeneralResponse> ChangeUserRoleAsync(ChangeRoleRequestDTO model);
        Task<IEnumerable<GetRoleDTO>> GetRolesAsync();
        Task<IEnumerable<GetUsersWithRoleDTO>> GetUsersWithRolesAsync();
    }
}
