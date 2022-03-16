using Animus.Business.Models.Users;
using Microsoft.AspNetCore.Http;

namespace Animus.Business.Services.Intrefaces
{
    public interface IAuthenticationService
    {
        UserModel? Authenticate(AuthenticationModel authenticationModel);
        void LogIn(HttpContext httpContext, AuthenticationModel authenticationModel);
        void LogOut(HttpContext httpContext, Guid id);
    }
}