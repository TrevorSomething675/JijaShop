namespace JijaShop.Models.DTOModels
{
    public class UserDto : BaseDtoEntity
    {
        public string UserDtoName { get; set; }
        public string UserDtoPassword { get; set; }
		public string UserEmail { get; set; }
	}
}
