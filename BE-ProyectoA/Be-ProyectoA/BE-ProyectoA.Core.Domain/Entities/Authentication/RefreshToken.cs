﻿namespace BE_ProyectoA.Core.Domain.Entities.Authentication
{
    public class RefreshToken
    {
        public int Id { get; set; }
        public string? UserId { get; set; }
        public string? Token { get; set; }   
    }
}
