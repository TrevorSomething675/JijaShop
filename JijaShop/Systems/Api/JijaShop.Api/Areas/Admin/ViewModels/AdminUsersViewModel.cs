using JijaShop.Api.Data.Models.DTOModels;

namespace JijaShop.Api.Areas.Admin.ViewModels
{
    public class AdminUsersViewModel
    {
        public List<UserDto> Users { get; set; } = new List<UserDto>();
    }
}
