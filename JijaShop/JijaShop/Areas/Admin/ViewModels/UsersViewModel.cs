using JijaShop.Models.DTOModels;

namespace JijaShop.Areas.Admin.ViewModels
{
    public class UsersViewModel
    {
        public List<UserDto> Users { get; set; } = new List<UserDto>();
    }
}
