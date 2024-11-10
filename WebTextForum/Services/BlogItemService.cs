using System.Security.Claims;
using WebTextForum.Entities;
using WebTextForum.Enums;
using WebTextForum.Helpers;
using WebTextForum.Interfaces;
using WebTextForum.ViewModel;

namespace WebTextForum.Services
{
    public class BlogItemService(IBlogItemsRepository blogItemsRepository, ITagsRepository tagsRepository) : IBlogItemService
    {
        private readonly IBlogItemsRepository _blogItemsRepository = blogItemsRepository;
        private readonly ITagsRepository _TagsRepository = tagsRepository;

        public async Task AddCommentAsync(string comment, ClaimsPrincipal user)
        {
            var userId = GetUserId(user);
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
            var userId = GetUserId(user);
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
            var item = await _blogItemsRepository.GetBlogItemAsync(id) ?? throw new Exception($"Blog Item not found for {id}");

            var userId = GetUserId(user);
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
            var item = await _blogItemsRepository.GetBlogItemAsync(id) ?? throw new Exception($"Blog Item not found for {id}");

            var userId = user.Identity.IsAuthenticated ? user.Claims.Where(c => c.Type.Equals("http://schemas.xmlsoap.org/ws/2005/05/identity/claims/nameidentifier", StringComparison.InvariantCultureIgnoreCase)).FirstOrDefault().Value
                : string.Empty;

            return await SetBlogItemLikeAsync(id, userId);
        }

        public async Task<BlogItemViewModel> SetBlogItemLikeAsync(string id, string userId)
        {
            var item = await _blogItemsRepository.GetBlogItemAsync(id) ?? throw new Exception($"Blog Item not found for {id}");

            if (item.Likes?.Count() == 0 || !item.Likes.Any(u => u.UserId == userId))
            {
                var like = new Entities.BlogItemLike
                {
                    UserId = userId,
                    CreatedDate = DateTime.Now,
                    Id = Guid.NewGuid().ToString()
                };
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

        public async Task<BlogItemsViewModel> GetBlogItemsAsync(int pageId, int perPage, OrderColumn orderColumn, bool desc)
        {
            var (items, count) = await _blogItemsRepository.GetBlogItemsAsync(pageId, perPage, orderColumn, desc);
            var model = new BlogItemsViewModel
            {
                Items = await items.ToDto(null, _TagsRepository),
                Count = count,
                PageNumber = pageId,
                PerPage = perPage
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
            var item = await _blogItemsRepository.GetBlogItemAsync(id) ?? throw new Exception($"Blog Item not found for {id}");

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

        private string GetUserId(ClaimsPrincipal user) => user?.Identity.IsAuthenticated ?? false
                ? user.Claims.Where(c => c.Type.Equals("http://schemas.xmlsoap.org/ws/2005/05/identity/claims/nameidentifier", StringComparison.InvariantCultureIgnoreCase)).FirstOrDefault().Value
                : string.Empty;

        public async Task<BlogItemsViewModel> SearchBlogItemsAsync(int pageId, int perPage, DateTime fromDate, DateTime toDate, OrderColumn orderColumn, bool desc)
        {
            var (items, count) = await _blogItemsRepository.SearchBlogItemsAsync(pageId, perPage, fromDate, toDate, orderColumn, desc);
            var model = new BlogItemsViewModel
            {
                Items = await items.ToDto(null, _TagsRepository),
                Count = count,
                PageNumber = pageId,
                PerPage = perPage
            };
            return model;
        }
    }
}
