namespace BE_ProyectoA.Core.Application.DTOs.Response
{
    public record LoginResponse
        (bool Flag = false, 
    string Message = null!
    ,string Token = null! 
    ,string RefreshToken = null!,
    string UserId = null!,
    string UserRole = null!);
   
}
