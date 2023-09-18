using System.Collections;
using System.Security.Claims;

namespace JijaShop.Services
{
    public class UserService
    {
        private readonly IHttpContextAccessor _contextAccessor;
        public UserService(IHttpContextAccessor httpContextAccessor)
        { 
            _contextAccessor = httpContextAccessor;
        }
        public string GetName()
        {
            var result = string.Empty;
            if(_contextAccessor != null)
            {
                return _contextAccessor.HttpContext.User.FindFirstValue(ClaimTypes.Name);
            }
            return result;
        }
    }
}
