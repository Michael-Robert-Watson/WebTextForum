using WebTextForum.Models;

namespace WebTextForum.Interfaces
{
    public interface IAppUserService
    {
        public Task<bool> Login(AppUser user);
    }
}
