namespace BE_ProyectoA.Core.Application.Dtos.Users
{
    public record RegisterRequest
    {
        public string Nombre { get; set; } = string.Empty;
        public string Apellido { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string UserName { get; set; } = string.Empty;
        public string PassWord { get; set; } = string.Empty;
        public string ConfirmPassWord { get; set; } = string.Empty;
    }
}
