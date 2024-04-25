using BE_ProyectoA.Core.Application.DTOs.Request.Account;
using BE_ProyectoA.Core.Application.DTOs.Response;
using BE_ProyectoA.Core.Application.DTOs.Response.Account;

namespace BE_ProyectoA.Core.Application.Interfaces
{
    public interface IAccount
    {
        Task CreateAdmin();
        Task<GeneralResponse> CreateAccountAsync(CreateAccountDTO model,CancellationToken cancellationToken);

        Task<LoginResponse> LoginAccountAsync(LoginDTO model);

        Task<GeneralResponse> CreateRoleAsync(CreateRoleDTO model);
        Task <LoginResponse> RefreshTokenAsync(RefreshTokenDTO model);
        Task<GeneralResponse> ChangeUserRoleAsync(ChangeRoleRequestDTO model);
        Task<IEnumerable<GetRoleDTO>>GetRolesAsync();
        Task<IEnumerable<GetUsersWithRoleDTO>> GetUsersWithRolesAsync();
    }
}
