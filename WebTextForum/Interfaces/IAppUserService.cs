using WebTextForum.ViewModel;

namespace WebTextForum.Interfaces
{
    public interface IAppUserService
    {
        public Task<bool> LoginAsync(AppUserViewModel user);
        Task LogOutAsync();
    }
}
