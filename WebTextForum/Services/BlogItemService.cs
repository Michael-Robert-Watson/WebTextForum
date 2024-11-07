using System.Security.Claims;
using System.Security.Principal;
using WebTextForum.Interfaces;
using WebTextForum.ViewModel;

namespace WebTextForum.Services
{
    public class BlogItemService : IBlogItemService
    {
        private readonly IBlogItemsRepository _blogItemsRepository;
        private readonly ITagsRepository _TagsRepository;

        public BlogItemService(IBlogItemsRepository blogItemsRepository, ITagsRepository tagsRepository)
        {
            _blogItemsRepository = blogItemsRepository;
            _TagsRepository = tagsRepository;
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
                Tags = item.Tags?.Select(t => new { text = t.Tag.Name, value = t.Tag.Id.ToString() }).ToArray() ?? [],
                User = item.User.UserName ?? "Unknown",
                LikedByUser = item.Likes.Any(u => u.UserId == userId),
                AllTags = (await _TagsRepository.GetTagsAsync()).Select(t => new { text = t.Name, value = t.Id.ToString() }).ToArray() ?? []
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
                Tags = item.Tags?.Select(t => new { text = t.Tag.Name, value = t.Tag.Id.ToString() }).ToArray() ?? [],
                User = item.User.UserName ?? "Unknown",
                LikedByUser = item.Likes.Any(u => u.UserId == userId),
                AllTags = (await _TagsRepository.GetTagsAsync()).Select(t => new { text = t.Name, value = t.Id.ToString() }).ToArray() ?? []
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

        public async Task UpdateTags(string id, string[] tagIds, ClaimsPrincipal user)
        {
            var item = await _blogItemsRepository.GetBlogItemAsync(id);
            if (item == null)
            {
                throw new Exception($"Blog Item not found for {id}");
            }

            var userId = user.Claims.Where(c => c.Type.Equals("http://schemas.xmlsoap.org/ws/2005/05/identity/claims/nameidentifier", StringComparison.InvariantCultureIgnoreCase)).FirstOrDefault().Value;

            item.Tags.Clear();
            foreach (var tag in tagIds)
            {
                item.Tags.Add(new Entities.BlogItemTag
                {
                    CreatedDate = DateTime.Now,
                    Id = Guid.NewGuid().ToString(),
                    TagId = tag,
                    UserId = userId
                });
            }

            await _blogItemsRepository.SaveChangesAsync();
        }
    }
}
