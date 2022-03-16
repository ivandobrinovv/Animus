using Animus.Business.Models.Users;
using Animus.Business.Services.Intrefaces;
using Microsoft.AspNetCore.Http;
using System.Text;

namespace Animus.Business.Services
{
    public class AuthenticationService : IAuthenticationService
    {
        private readonly IUserService _userService;
        public AuthenticationService(IUserService userService)
        {
            _userService = userService;
        }
        public UserModel? Authenticate(AuthenticationModel authenticationModel)
        {
            try
            {
                UserModel userModel = _userService.GetUserByEmail(authenticationModel.Email);
                return BCrypt.Net.BCrypt
                     .Verify(authenticationModel.Password, userModel.Password)
                     ? userModel : null;
            }
            catch (Exception)
            {
                return null;
            }
        }

        public void LogIn(HttpContext httpContext, AuthenticationModel authenticationModel)
        {

            UserModel? userModel = Authenticate(authenticationModel);
            if (userModel is null)
            {
                return;
            }
            httpContext.Session
                .Set(nameof(userModel.Id), Encoding.UTF8.GetBytes(userModel.Id.ToString()));

        }

        public void LogOut(HttpContext httpContext, Guid id)
        {
            httpContext.Session.Clear();
        }
    }
}
