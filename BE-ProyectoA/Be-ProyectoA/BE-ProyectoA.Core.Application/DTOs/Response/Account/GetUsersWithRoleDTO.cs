namespace BE_ProyectoA.Core.Application.DTOs.Response.Account
{
    public class GetUsersWithRoleDTO
    {
        public string? Name { get; set; } 
        public string? Email { get; set; }
        public string? RoleId { get; set;}
        public string? RoleName { get; set;}
    }
}
