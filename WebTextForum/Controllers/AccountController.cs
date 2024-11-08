using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using WebTextForum.Interfaces;
using WebTextForum.ViewModel;

namespace WebTextForum.Controllers
{
    public class AccountController : Controller
    {
        private readonly ILogger<AccountController> _logger;
        private readonly IAppUserService _appUserService;
        private readonly SignInManager<IdentityUser> _userManager;

        public AccountController(ILogger<AccountController> logger, IAppUserService appUserService, SignInManager<IdentityUser> userManager)
        {
            _logger = logger;
            _appUserService = appUserService;
            _userManager = userManager;
        }

        [AllowAnonymous]
        [HttpGet]
        public async Task<IActionResult> Login()
        {
            return View(new AppUserViewModel());
        }

        [AllowAnonymous]
        [HttpGet]
        public async Task<IActionResult> LogOut()
        {
            await _appUserService.LogOutAsync();
            return RedirectToAction("Login");
        }

        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> Login(AppUserViewModel user)
        {
            var login = await _appUserService.LoginAsync(user);
            if (login)
            {
                return RedirectToAction("Index", "Forum");
            }
            return View(new AppUserViewModel { UserName = user.UserName, Successful = false });
        }
    }
}
