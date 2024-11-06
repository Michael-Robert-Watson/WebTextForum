using WebTextForum.Models;

namespace WebTextForum.Interfaces
{
    public interface IAppUserRepository
    {
            Task<int> AddPlayerAsync(AppUser player);
            Task<IEnumerable<AppUser>> GetAllAsync();
            Task<AppUser> GetAsync(int id);
            Task<AppUser> GetAsync(string name);
            Task SaveChangesAsync();
            Task DeleteAsync(AppUser appUserFromId);
    }
}
