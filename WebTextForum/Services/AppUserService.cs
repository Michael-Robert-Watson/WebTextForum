using Microsoft.AspNetCore.Identity;
using WebTextForum.Interfaces;
using WebTextForum.ModelView;

namespace WebTextForum.Services
{
    public class AppUserService : IAppUserService
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly SignInManager<IdentityUser> _signInManager;

        public AppUserService(UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        public async Task<bool> Login(AppUserViewModel user)
        {
            IdentityUser signedUser = await _userManager.FindByNameAsync(user.UserName.ToUpper());
            var result = await _signInManager.PasswordSignInAsync(signedUser.UserName, user.Password, false, false);

            return result.Succeeded;
        }
    }
}
