using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using WebTextForum.Helpers;
using WebTextForum.Interfaces;
using WebTextForum.Models;
using WebTextForum.ModelView;

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
        [HttpPost]
        public async Task<IActionResult> Login(AppUserViewModel user)
        {
            var login = await _appUserService.Login(user);
            if (login)
            {
                return RedirectToAction("Index", "Home");
            }
            return View(new AppUserViewModel { UserName = user.UserName, Successful = false });
        }
    }
}
