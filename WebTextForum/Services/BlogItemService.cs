using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Security.Principal;
using WebTextForum.Interfaces;
using WebTextForum.ViewModel;

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

        public async Task<BlogItemViewModel> GetBlogItemAsync(string id, System.Security.Claims.ClaimsPrincipal user)
        {
            var item = await _blogItemsRepository.GetBlogItemAsync(id);
            if (item == null)
            {
                throw new Exception($"Blog Item not found for {id}");
            }
            
            var userId = user.Claims.Where(c => c.Type.Equals("http://schemas.xmlsoap.org/ws/2005/05/identity/claims/nameidentifier", StringComparison.InvariantCultureIgnoreCase)).FirstOrDefault().Value;

            var model = new BlogItemViewModel()
            {
                Comment = item.Comment,
                CreatedDate = item.CreatedDate.ToString("dd MMM yyyy HH:mm"),
                Likes = item.Likes?.Count() ?? 0,
                Tags = item.Tags?.Select(t => new { text = t.Tag.Name, value = t.Id.ToString() }).ToArray() ?? [],
                User = item.User.UserName ?? "Unknown",
                LikedByUser = item.Likes.Any(u=>u.UserId==userId)
            };

            return model;
        }

        public async Task<BlogItemViewModel> GetBlogItemLikeAsync(string id, System.Security.Claims.ClaimsPrincipal user)
        {
            var item = await _blogItemsRepository.GetBlogItemAsync(id);
            if (item == null)
            {
                throw new Exception($"Blog Item not found for {id}");
            }

            var userId = user.Claims.Where(c => c.Type.Equals("http://schemas.xmlsoap.org/ws/2005/05/identity/claims/nameidentifier", StringComparison.InvariantCultureIgnoreCase)).FirstOrDefault().Value;

            if (item.Likes?.Count() == 0 || !item.Likes.Any(u => u.UserId == userId))
            {
                var like = new Entities.BlogItemLike();
                like.UserId = userId;
                like.CreatedDate = DateTime.Now;
                like.Id = Guid.NewGuid().ToString();
                item.Likes.Add(like);
                await _blogItemsRepository.SaveChangesAsync();
            }
            else
            {
                var like = item.Likes.FirstOrDefault(u => u.UserId == userId);
                item.Likes.Remove(like);
                await _blogItemsRepository.SaveChangesAsync();
            }

            var model = new BlogItemViewModel()
            {
                Comment = item.Comment,
                CreatedDate = item.CreatedDate.ToString("dd MMM yyyy HH:mm"),
                Likes = item.Likes?.Count() ?? 0,
                Tags = item.Tags?.Select(t => new { text = t.Tag.Name, value = t.Id.ToString() }).ToArray() ?? [],
                User = item.User.UserName ?? "Unknown"
            };

            return model;
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
