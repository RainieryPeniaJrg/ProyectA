namespace BE_ProyectoA.Core.Application.Dtos.Users
{
    public record AuthenticationRequest
    {
        public string Email { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
    }
}
