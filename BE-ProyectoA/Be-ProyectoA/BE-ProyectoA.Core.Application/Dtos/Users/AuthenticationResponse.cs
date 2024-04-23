using System.Text.Json.Serialization;

namespace BE_ProyectoA.Core.Application.Dtos.Users
{
    public record AuthenticationResponse 
    {
        public string Id { get; set; } = string.Empty;
        public string UserName { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public List<string> Roles { get; set; }
        public bool? IsAuthenticated { get; set; }
        public string? JWToken { get; set; } = string.Empty;
        [JsonIgnore]
        public string? RefreshToken { get; set; } = string.Empty;
    }
}
