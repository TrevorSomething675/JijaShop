using System.ComponentModel.DataAnnotations.Schema;

namespace JijaShop.Api.Data.Models.DTOModels
{
	public class ProductImageDto : BaseEntityDto
	{
		public IFormFile Image { get; set; } = null!;
		public string ImageName { get; set; } = "";
		public string ImagePath { get; set; } = "";
	}
}
