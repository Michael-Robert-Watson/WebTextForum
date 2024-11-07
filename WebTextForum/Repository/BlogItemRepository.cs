using Microsoft.EntityFrameworkCore;
using WebTextForum.Entities;
using WebTextForum.Helpers;
using WebTextForum.Interfaces;

namespace WebTextForum.Repository
{
    public class BlogItemRepository : IBlogItemsRepository
    {
        private readonly DataContext _dataContext;

        public BlogItemRepository(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public async Task<(IEnumerable<BlogItem>, int)> GetBlogItemsAsync(int pageId, int perPage)
        {
            var item = _dataContext.BlogItems.Include(t => t.Likes).Include(t => t.Tags).Include(u => u.User).Where(i => i.BlogItemParentId == null);

            return (await item.Include(t => t.Tags).Skip(perPage * pageId).Take(perPage).ToListAsync(),
                item.Count());
        }
    }
}
