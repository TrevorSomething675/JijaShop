﻿namespace JijaShop.Models
{
    public class User : BaseEntity
    {
        public string? UserName { get; set; }
        public string? UserPassword { get; set; }
        public string? UserEmail { get; set; }
        public string? UserPhone { get; set; }
        public int? UserAge { get; set; }
    }
}
