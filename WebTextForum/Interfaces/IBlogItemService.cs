using Microsoft.AspNetCore.Identity;
using System.Security.Principal;
using WebTextForum.ModelView;

namespace WebTextForum.Interfaces
{
    public interface IBlogItemService
    {
        Task<BlogItemsViewModel> GetBlogItemsAsync(int pageId, int perPage, IIdentity user);
    }
}
