using BE_ProyectoA.Core.Application.Dtos.Users;
using BE_ProyectoA.Core.Application.Wrappers;
using MediatR;

namespace BE_ProyectoA.Core.Application.Features.Usuarios.Authenticated.Commands
{
    public class AuthenticatedCommand : IRequest<Response<AuthenticationResponse>>
    {
        public string  Email { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        public string IpAdress {  get; set; } = string.Empty;
    }
}
