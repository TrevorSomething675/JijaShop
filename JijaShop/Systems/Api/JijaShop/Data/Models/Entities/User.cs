namespace JijaShop.Data.Models.Entities
{
    public class User : BaseEntity
    {
        public string UserName { get; set; }
        public string UserEmail { get; set; }
        public string? UserPhone { get; set; }
        public int? UserAge { get; set; }
        public byte[]? UserPasswordHash { get; set; }
        public byte[]? UserPasswordSalt { get; set; }
    }
}