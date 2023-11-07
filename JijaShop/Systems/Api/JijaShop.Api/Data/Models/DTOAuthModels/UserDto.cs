using JijaShop.Api.Data.Models.DTOModels;
using JijaShop.Api.Data.Models.Entities;

namespace JijaShop.Api.Data.Models.AuthDtoModels
{
    public class UserDto : BaseEntityDto
    {
        public string UserName { get; set; }
        public string UserPassword { get; set; }
        public string UserEmail { get; set; }
        public int? UserAge { get; set; }

		public int CartProductId { get; set; }
		public ProductDto CartProduct { get; set; }

		public int FavoriteProductId { get; set; }
		public ProductDto FavoriteProduct { get; set; }
	}
}
