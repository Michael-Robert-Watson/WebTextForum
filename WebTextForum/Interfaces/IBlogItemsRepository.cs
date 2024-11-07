using WebTextForum.Entities;

namespace WebTextForum.Interfaces
{
    public interface IBlogItemsRepository
    {
        Task<(IEnumerable<BlogItem>, int)> GetBlogItemsAsync(int pageId, int perPage);
    }
}
