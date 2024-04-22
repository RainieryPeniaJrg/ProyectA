using BE_ProyectoA.Core.Application.Dtos.Users;
using BE_ProyectoA.Core.Application.Wrappers;

namespace BE_ProyectoA.Core.Application.Interfaces
{
    public interface IAccountServices
    {
        Task<Response<AuthenticationResponse>> AuthenticatedAsync(AuthenticationRequest request, string ipAddress);
        Task<Response<string>> RegisterAsync(RegisterRequest request, string origin);
    }
}
