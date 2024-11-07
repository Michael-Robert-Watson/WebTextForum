using Microsoft.AspNetCore.Identity;
using System.Security.Principal;
using WebTextForum.Interfaces;
using WebTextForum.ModelView;

namespace WebTextForum.Services
{
    public class BlogItemService : IBlogItemService
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly IBlogItemsRepository _blogItemsRepository;

        public BlogItemService(UserManager<IdentityUser> userManager, IBlogItemsRepository blogItemsRepository)
        {
            _userManager = userManager;
            _blogItemsRepository = blogItemsRepository;
        }

        public async Task<BlogItemsViewModel> GetBlogItemsAsync(int pageId, int perPage, IIdentity user)
        {
            var (items, count) = await _blogItemsRepository.GetBlogItemsAsync(pageId, perPage);
            var model = new BlogItemsViewModel
            {
                User = user,
                Items = items.ToList(),
                Count = count,
                 PageNumber = pageId
            };
            return model;
        }
    }
}
