using WebTextForum.Entities;

namespace WebTextForum.Interfaces
{
    public interface IBlogItemsRepository
    {
        Task<BlogItem> AddBlogItemsAsync(BlogItem item);
        Task<(IEnumerable<BlogItem>, int)> GetBlogItemsAsync(int pageId, int perPage);
        Task<BlogItem> GetBlogItemAsync(string id);
        Task SaveChangesAsync();
        Task<IEnumerable<BlogItem>> GetRepliesToPostAsync(string id);
    }
}
