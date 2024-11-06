using Microsoft.EntityFrameworkCore;
using WebTextForum.Helpers;
using WebTextForum.Interfaces;
using WebTextForum.Models;

namespace WebTextForum.Repository
{
    public class AppUserRepository : IAppUserRepository
    {
        private readonly DataContext _context;

        public AppUserRepository(DataContext context)
        {
            _context = context;
        }

        public Task<int> AddPlayerAsync(AppUser player)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(AppUser appUserFromId)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<AppUser>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<AppUser> GetAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<AppUser> GetAsync(string name)
        {
            try
            {
                return await _context.AppUsers.FirstOrDefaultAsync(u => u.UserName.ToLower().Equals(name.ToLower()));
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public Task SaveChangesAsync()
        {
            throw new NotImplementedException();
        }
    }
}
