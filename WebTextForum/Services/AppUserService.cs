using WebTextForum.Helpers;
using WebTextForum.Interfaces;
using WebTextForum.Models;

namespace WebTextForum.Services
{
    public class AppUserService : IAppUserService
    {
        private readonly IAppUserRepository _repository;

        public AppUserService(IAppUserRepository repository)
        {
            _repository = repository;
        }

        public async Task<bool> Login(AppUser user)
        {
            var userFromDb = await _repository.GetAsync(user.UserName);
            
            if (userFromDb == null)
            {
                return false;
            }

            return string.Equals(Security.HashedPassword(user.Password), userFromDb.Password);
        }
    }
}
