using JijaShop.Repositories.Abstractions;
using JijaShop.Models.Entities;
using System.Linq.Expressions;

namespace JijaShop.Services
{
	public class IdentityService
	{
		private readonly IUserRepository _userRepository;
		private readonly ILogger<IdentityService> _logger;
		public IdentityService(IUserRepository userRepository, ILogger<IdentityService> logger) 
		{ 
			_userRepository = userRepository;
			_logger = logger;
		}

		public async Task RegisterUser(User requestUser)
		{
			if (!IsRegister(requestUser))
			{
				//Пользователь уже существует
			}
			else
			{
				await _userRepository.CreateUser(requestUser);
			}
		}

		public async Task LoginUser(User requestUser)
		{
			if (IsRegister(requestUser))
			{
				//Войти
			}
			else
			{
				//Пользователь не существует
			}
		}
		private bool IsRegister(User requestUser)
		{
			Expression<Func<User, bool>> filter = filterUser => filterUser.UserName == requestUser.UserName;
			var user = _userRepository.GetUser(filter);

			if(user != null)
				return true;
			else
				return false;
		}
	}
}
