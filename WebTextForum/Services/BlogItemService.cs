using System.Security.Claims;
using WebTextForum.Entities;
using WebTextForum.Helpers;
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

        public async Task AddCommentAsync(string comment, ClaimsPrincipal user)
        {
            var userId = getUserId(user);
            await AddCommentAsync(comment, userId);
        }

        public async Task AddCommentAsync(string comment, string userId)
        {
            await _blogItemsRepository.AddBlogItemsAsync(new BlogItem()
            {
                Id = Guid.NewGuid().ToString(),
                Comment = comment,
                CreatedDate = DateTime.Now,
                UserId = userId
            });
        }

        public async Task AddReplyAsync(string id, ClaimsPrincipal user, string comment)
        {
            var userId = getUserId(user);
            await AddReplyAsync(id, userId, comment);
        }

        public async Task AddReplyAsync(string id, string userId, string comment)
        {
            await _blogItemsRepository.AddBlogItemsAsync(new BlogItem()
            {
                Id = Guid.NewGuid().ToString(),
                BlogItemParentId = id,
                Comment = comment,
                CreatedDate = DateTime.Now,
                UserId = userId
            });
        }
        public async Task<BlogItemViewModel> GetBlogItemAsync(string id, ClaimsPrincipal user)
        {
            var item = await _blogItemsRepository.GetBlogItemAsync(id);
            if (item == null)
            {
                throw new Exception($"Blog Item not found for {id}");
            }

            var userId = getUserId(user);
            BlogItemViewModel model = await item.ToDto(userId, _TagsRepository);

            var replies = await _blogItemsRepository.GetRepliesToPostAsync(id);
            foreach (var rep in replies)
            {
                model.Replies.Add(await rep.ToDto(userId, _TagsRepository));
            }

            return model;
        }

        public async Task<BlogItemViewModel> SetBlogItemLikeAsync(string id, ClaimsPrincipal user)
        {
            var item = await _blogItemsRepository.GetBlogItemAsync(id);
            if (item == null)
            {
                throw new Exception($"Blog Item not found for {id}");
            }

            var userId = user.Identity.IsAuthenticated ? user.Claims.Where(c => c.Type.Equals("http://schemas.xmlsoap.org/ws/2005/05/identity/claims/nameidentifier", StringComparison.InvariantCultureIgnoreCase)).FirstOrDefault().Value
                : string.Empty;

            return await SetBlogItemLikeAsync(id, userId);
        }

        public async Task<BlogItemViewModel> SetBlogItemLikeAsync(string id, string userId)
        {
            var item = await _blogItemsRepository.GetBlogItemAsync(id);
            if (item == null)
            {
                throw new Exception($"Blog Item not found for {id}");
            }

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

            return await item.ToDto(userId, _TagsRepository);
        }

        public async Task<BlogItemsViewModel> GetBlogItemsAsync(int pageId, int perPage)
        {
            var (items, count) = await _blogItemsRepository.GetBlogItemsAsync(pageId, perPage);
            var model = new BlogItemsViewModel
            {
                Items = await items.ToDto(null, _TagsRepository),
                Count = count,
                PageNumber = pageId
            };
            return model;
        }

        public async Task UpdateTagsAsync(string id, string[] tagIds, ClaimsPrincipal user)
        {
            var userId = user.Claims.Where(c => c.Type.Equals("http://schemas.xmlsoap.org/ws/2005/05/identity/claims/nameidentifier", StringComparison.InvariantCultureIgnoreCase)).FirstOrDefault().Value;

            await UpdateTagsAsync(id, tagIds, userId);
        }

        public async Task UpdateTagsAsync(string id, string[] tagIds, string userId)
        {
            var item = await _blogItemsRepository.GetBlogItemAsync(id);
            if (item == null)
            {
                throw new Exception($"Blog Item not found for {id}");
            }

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

        private string getUserId(ClaimsPrincipal user)
        {
            return user?.Identity.IsAuthenticated ?? false
                ? user.Claims.Where(c => c.Type.Equals("http://schemas.xmlsoap.org/ws/2005/05/identity/claims/nameidentifier", StringComparison.InvariantCultureIgnoreCase)).FirstOrDefault().Value
                : string.Empty;
        }
    }
}
