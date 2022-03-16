using Animus.Business.Models.Users;
using Animus.Business.Services.Intrefaces;
using Microsoft.AspNetCore.Mvc;


namespace Animus.Web.Controllers
{
    public class UsersController : Controller
    {
        private readonly IUserService _userService;
        public UsersController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet]
        public IActionResult Index()
        {
            List<UserModel> users = _userService.GetAll();
            return View(users);
        }

    }
}
