using WebTextForum.ViewModel;

namespace WebTextForum.Interfaces
{
    public interface IAppUserService
    {
        public Task<bool> Login(AppUserViewModel user);
    }
}
