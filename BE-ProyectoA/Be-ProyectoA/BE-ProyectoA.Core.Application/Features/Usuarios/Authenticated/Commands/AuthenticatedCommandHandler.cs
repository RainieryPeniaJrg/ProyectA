using BE_ProyectoA.Core.Application.Dtos.Users;
using BE_ProyectoA.Core.Application.Interfaces;
using BE_ProyectoA.Core.Application.Wrappers;
using MediatR;

namespace BE_ProyectoA.Core.Application.Features.Usuarios.Authenticated.Commands
{
    public class AuthenticatedCommandHandler : IRequestHandler<AuthenticatedCommand, Response<AuthenticationResponse>>
    {
        private readonly IAccountServices _accountServices;

        public AuthenticatedCommandHandler(IAccountServices accountServices)
        {
            _accountServices = accountServices;
        }

 
        public async Task<Response<AuthenticationResponse>> Handle(AuthenticatedCommand request, CancellationToken cancellationToken)
        {
            return await _accountServices.AuthenticatedAsync(new AuthenticationRequest
            {
                Email = request.Email,
                Password = request.Password,

            }, request.IpAdress); ;
        }
    }
}
