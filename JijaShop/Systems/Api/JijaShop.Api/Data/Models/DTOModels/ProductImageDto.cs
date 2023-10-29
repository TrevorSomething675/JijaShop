namespace JijaShop.Api.Data.Models.DTOModels
{
	public class ProductImageDto : BaseEntityDto
	{
		public IFormFile Image { get; set; } = null!;
		public string ImageName { get; set; } = null!;
		public byte[] ImageContent { get; set; } = null!;
	}
}
