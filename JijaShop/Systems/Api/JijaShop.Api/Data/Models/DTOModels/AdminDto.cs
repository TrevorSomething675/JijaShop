namespace JijaShop.Api.Data.Models.DTOModels
{
    public class AdminDto : BaseEntityDto
    {
        public string AdminName { get; set; }
        public string AdminPassword { get; set; }
        public string? AdminEmail { get; set; }
    }
}
