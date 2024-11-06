using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Security.Cryptography;
using System.Text;
using WebTextForum.Interfaces;
using WebTextForum.Models;
using WebTextForum.ModelView;

namespace WebTextForum.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IAppUserService _appUserService;

        public HomeController(ILogger<HomeController> logger, IAppUserService appUserService)
        {
            _logger = logger;
            _appUserService = appUserService;
        }

        [AllowAnonymous]
        [HttpGet]
        public IActionResult Index()
        {
            return View(new AppUserViewModel());
        }

        [HttpPost]
        public async Task<IActionResult> Index(AppUser user)
        {
            var login = await _appUserService.Login(user);
            if (login)
            {
                
                return Redirect("Forum");
            }
            return View(new AppUserViewModel {UserName = user.UserName, Successful = false });
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
