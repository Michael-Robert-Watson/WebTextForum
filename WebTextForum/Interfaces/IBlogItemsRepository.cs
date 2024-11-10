using WebTextForum.Entities;
using WebTextForum.Enums;

namespace WebTextForum.Interfaces
{
    public interface IBlogItemsRepository
    {
        Task<BlogItem> AddBlogItemsAsync(BlogItem item);
        Task<(IEnumerable<BlogItem>, int)> GetBlogItemsAsync(int pageId, int perPage, OrderColumn orderColumn, bool desc);
        Task<BlogItem> GetBlogItemAsync(string id);
        Task SaveChangesAsync();
        Task<IEnumerable<BlogItem>> GetRepliesToPostAsync(string id);
        Task<(IEnumerable<BlogItem>, int)> SearchBlogItemsAsync(int pageId, int perPage, DateTime fromDate, DateTime toDate, OrderColumn orderColumn, bool desc);
    }
}
