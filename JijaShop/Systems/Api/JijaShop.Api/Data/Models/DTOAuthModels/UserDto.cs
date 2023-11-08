using JijaShop.Api.Data.Models.DTOModels;

namespace JijaShop.Api.Data.Models.AuthDtoModels
{
    public class UserDto : BaseEntityDto
    {
        public string UserName { get; set; }
        public string UserPassword { get; set; }
        public string UserEmail { get; set; }
        public int? UserAge { get; set; }
	}
}