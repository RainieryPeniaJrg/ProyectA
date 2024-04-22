namespace BE_ProyectoA.Core.Application.Dtos.Users
{
    public record AuthenticationRequest
    {
        public string? Email { get; set; }
        public string? Password { get; set; }
    }
}
