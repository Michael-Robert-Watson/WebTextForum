using Microsoft.AspNetCore.Identity;
using WebTextForum.Interfaces;
using WebTextForum.ViewModel;

namespace WebTextForum.Services
{
    public class AppUserService(UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager) : IAppUserService
    {
        private readonly UserManager<IdentityUser> _userManager = userManager;
        private readonly SignInManager<IdentityUser> _signInManager = signInManager;

        public async Task<bool> LoginAsync(AppUserViewModel user)
        {
            IdentityUser signedUser = await _userManager.FindByNameAsync(user.UserName.ToUpper());
            var result = await _signInManager.PasswordSignInAsync(signedUser.UserName, user.Password, false, false);

            return result.Succeeded;
        }

        public async Task LogOutAsync()
        {
            await _signInManager.SignOutAsync();
        }
    }
}
