using JijaShop.Api.Data.Models.AuthDtoModels;
using JijaShop.Api.Data.Models.AuthEntities;
using AutoMapper;

namespace JijaShop.Api.Configurations.AutoMapper.Mappings
{
    public class UserMap : Profile
    {
        public UserMap() 
        {
            CreateMap<UserDto, User>().
                ForMember(user => user.Email, opt =>
                    opt.MapFrom(userDto => userDto.UserEmail));

            CreateMap<User, UserDto>().
                ForMember(userDto => userDto.UserEmail, opt =>
                    opt.MapFrom(user => user.Email));
        }
    }
}
