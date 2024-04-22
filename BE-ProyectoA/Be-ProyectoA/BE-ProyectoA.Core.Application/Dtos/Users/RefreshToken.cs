namespace BE_ProyectoA.Core.Application.Dtos.Users
{
    public class RefreshToken
    {
        public int Id { get; set; }
        public string Token { get; set; }
        public DateTime Expires { get; set; }
        public bool isExpired => DateTime.UtcNow >= Expires;
        public DateTime Created { get; set; }
        public string CreatedByIp { get; set; }
        public DateTime? Revoked { get; set; }
        public string RevokedIp { get; set; }
        public string ReplacedByToken { get; set; }
        public bool IsActive => Revoked == null && !isExpired;
    }
}
