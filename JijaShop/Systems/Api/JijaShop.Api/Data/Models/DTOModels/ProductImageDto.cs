namespace JijaShop.Api.Data.Models.DTOModels
{
	public class ProductImageDto : BaseEntityDto
	{
		public IFormFile Image { get; set; } = null!;
		public string ImageNameDto { get; set; } = null!;
		public string ImagePathDto { get; set; } = null!;
	}
}
