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
        public async Task<IActionResult> Index()
        {
            List<UserModel> users = await _userService.GetAll();
            return View(users);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(UserModel model)
        {
            try
            {
                await _userService.AddAsync(model);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception)
            {
                return View(model);
            }
            
        }

        [HttpGet]
        public async Task<IActionResult> Details(Guid id)
        {
            try
            {
                UserModel user = await _userService.GetUserAsync(id);
                return View(user);
            }
            catch (ArgumentException e)
            {
                ViewData["Message"] = e.Message;
                return RedirectToAction(nameof(Index));
            }
           
        }
        [HttpGet]
        public async Task<IActionResult> Delete(Guid id)
        {
            try
            {
                UserModel user = await _userService.GetUserAsync(id);
                return View(user);
            }
            catch (ArgumentException e)
            {
                ViewData["Message"] = e.Message;
                return RedirectToAction(nameof(Index));
            }
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmation(Guid id)
        {
            try
            {
                await _userService.DeleteAsync(id);
                return RedirectToAction(nameof(Index));
            }
            catch (ArgumentException e)
            {
                ViewData["Message"] = e.Message;

                return RedirectToAction(nameof(Index));
            }
        }
    }
}
