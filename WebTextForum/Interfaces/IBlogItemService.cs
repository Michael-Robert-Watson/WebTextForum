using System.Security.Claims;
using System.Security.Principal;
using WebTextForum.ViewModel;

namespace WebTextForum.Interfaces
{
    public interface IBlogItemService
    {
        Task AddCommentAsync(string comment, ClaimsPrincipal user);
        Task AddCommentAsync(string comment, string userId);
        Task AddReplyAsync(string id, ClaimsPrincipal user, string comment);
        Task AddReplyAsync(string id, string userId, string comment);
        Task<BlogItemViewModel> GetBlogItemAsync(string id, ClaimsPrincipal user);
        Task<BlogItemViewModel> SetBlogItemLikeAsync(string id, ClaimsPrincipal user);
        Task<BlogItemViewModel> SetBlogItemLikeAsync(string id, string userId);
        Task<BlogItemsViewModel> GetBlogItemsAsync(int pageId, int perPage);
        Task UpdateTagsAsync(string id, string[] tagIds, ClaimsPrincipal user);
        Task UpdateTagsAsync(string id, string[] tagIds, string userId);
    }
}
