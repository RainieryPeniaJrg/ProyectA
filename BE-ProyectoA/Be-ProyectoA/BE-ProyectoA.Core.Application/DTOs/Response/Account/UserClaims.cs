namespace BE_ProyectoA.Core.Application.DTOs.Response.Account
{
    public record UserClaims
        (string FullName = null!
        ,string UserName = null!,
        string Email = null!,
        string Role =null!);
 
}
