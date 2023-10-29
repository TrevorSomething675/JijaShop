namespace JijaShop.Api.Data.Models.Entities
{
	public class ProductImage : BaseEntity
	{
		public string ImageName { get; set; } = null!;
		public byte[] ImageContent { get; set; } = null!;
	}
}
