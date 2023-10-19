using JijaShop.Data.Models.DTOModels;

namespace JijaShop.Areas.Admin.ViewModels
{
    public class AdminUsersViewModel
    {
        public List<UserDto> Users { get; set; } = new List<UserDto>();
    }
}
