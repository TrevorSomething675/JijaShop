namespace JijaShop.Models.DTOModels
{
    public class UserDto : BaseDtoEntity
    {
        public string UserName { get; set; }
        public string UserPassword { get; set; }
		public string? UserEmail { get; set; }
        public int? UserAge { get; set; }
    }
}