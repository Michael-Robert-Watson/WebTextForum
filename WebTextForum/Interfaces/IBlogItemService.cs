using System.Security.Claims;
using System.Security.Principal;
using WebTextForum.ViewModel;

namespace WebTextForum.Interfaces
{
    public interface IBlogItemService
    {
        Task<BlogItemViewModel> GetBlogItemAsync(string id, System.Security.Claims.ClaimsPrincipal user);
        Task<BlogItemViewModel> GetBlogItemLikeAsync(string id, System.Security.Claims.ClaimsPrincipal user);
        Task<BlogItemsViewModel> GetBlogItemsAsync(int pageId, int perPage, IIdentity user);
        Task UpdateTags(string id, string[] tagIds, ClaimsPrincipal user);
    }
}
