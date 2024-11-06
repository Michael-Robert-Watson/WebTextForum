using WebTextForum.Models;
using WebTextForum.ModelView;

namespace WebTextForum.Interfaces
{
    public interface IAppUserService
    {
        public Task<bool> Login(AppUserViewModel user);
    }
}
