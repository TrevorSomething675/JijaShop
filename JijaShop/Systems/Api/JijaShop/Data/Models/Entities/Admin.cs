namespace JijaShop.Data.Models.Entities
{
    public class Admin : BaseEntity
    {
        public string AdminName { get; set; }
        public string AdminIp { get; set; }
        public string AdminEmail { get; set; }
        public string AdminPassword { get; set; }
        public byte[]? AdminPasswordHash { get; set; }
        public byte[]? AdminPasswordSalt { get; set; }
    }
}
