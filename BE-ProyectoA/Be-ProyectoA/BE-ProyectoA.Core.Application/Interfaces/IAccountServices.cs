using Be_NetBanking.Core.Application.Wrappers;
using BE_ProyectoA.Core.Application.Dtos.Users;

namespace BE_ProyectoA.Core.Application.Interfaces
{
    public interface IAccountServices
    {
        Task<Response<AuthenticationResponse>> AuthenticatedAsync(AuthenticationRequest request, string ipAddress);
        Task<Response<string>> RegisterAsync(RegisterRequest request, string origin);
    }
}
