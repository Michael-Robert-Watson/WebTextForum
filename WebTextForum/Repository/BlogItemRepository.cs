using Microsoft.EntityFrameworkCore;
using WebTextForum.Entities;
using WebTextForum.Enums;
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

        public async Task<BlogItem> AddBlogItemsAsync(BlogItem item)
        {
            _dataContext.BlogItems.Add(item);
            await _dataContext.SaveChangesAsync();
            return item;
        }

        public async Task<BlogItem> GetBlogItemAsync(string id)
        {
            return await _dataContext.BlogItems.Include(t => t.Likes).Include(t => t.Tags).ThenInclude(t => t.Tag).Include(u => u.User)
                .FirstOrDefaultAsync(i => i.Id == id);
        }

        public async Task<(IEnumerable<BlogItem>, int)> GetBlogItemsAsync(int pageId, int perPage, OrderColumn orderColumn, bool desc)
        {
            var items = _dataContext.BlogItems.Include(t => t.Likes)
                .Include(t => t.Tags).Include(u => u.User).Where(i => i.BlogItemParentId == null);
            items = OrderItems(orderColumn, desc, items);

            return (await items.Skip(perPage * pageId).Take(perPage).ToListAsync(),
                items.Count());
        }

        private static IQueryable<BlogItem> OrderItems(OrderColumn orderColumn, bool desc, IQueryable<BlogItem> items)
        {
            if (desc)
            {
                switch (orderColumn)
                {
                    case OrderColumn.Date:
                        items = items.OrderByDescending(o => o.CreatedDate);
                        break;
                    case OrderColumn.User:
                        items = items.OrderByDescending(o => o.User);
                        break;
                    case OrderColumn.Comment:
                        items = items.OrderByDescending(o => o.Comment);
                        break;
                }
            }
            else
            {
                switch (orderColumn)
                {
                    case OrderColumn.Date:
                        items = items.OrderBy(o => o.CreatedDate);
                        break;
                    case OrderColumn.User:
                        items = items.OrderBy(o => o.User);
                        break;
                    case OrderColumn.Comment:
                        items = items.OrderBy(o => o.Comment);
                        break;
                }
            }

            return items;
        }

        public async Task<IEnumerable<BlogItem>> GetRepliesToPostAsync(string id)
        {
            return await _dataContext.BlogItems.Include(t => t.Likes).Include(t => t.Tags).ThenInclude(t => t.Tag).Include(u => u.User)
                .Where(item => item.BlogItemParentId == id).OrderBy(o => o.CreatedDate).ToListAsync();
        }

        public async Task SaveChangesAsync()
        {
            await _dataContext.SaveChangesAsync();
        }

        private class junk
        {
            public string Id { get; set; }
            public int count { get; set; }
        }
        public async Task<(IEnumerable<BlogItem>, int)> SearchBlogItemsAsync(int pageId, int perPage, DateTime fromDate, DateTime toDate, OrderColumn orderColumn, bool desc)
        {
            if (orderColumn == OrderColumn.Likes)
            {
                var likes = _dataContext.BlogItemLikes.GroupBy(l => l.BlogItem).Select(s => new { count = s.Count(), s.Key });
                var countedLikes = _dataContext.BlogItems.Include(i => i.Likes).SelectMany(p => p.Likes, (p, c) => new { p.Id, likeId = c.Id }).GroupBy(i => i.Id)
                    .Select(s => new junk { Id = s.Key, count = s.Count() });
                var countedLikesUnionedWithNoLikes = countedLikes.Union(_dataContext.BlogItems.Where(s => !countedLikes.Any(d => d.Id == s.Id)).Select(s => new junk { Id = s.Id, count = 0 }));
                var itemsToReturn = _dataContext.BlogItems.Where(i => i.CreatedDate >= fromDate && i.CreatedDate <= toDate).Include(t => t.Likes)
                    .Include(t => t.Tags).Include(u => u.User).Where(i => i.BlogItemParentId == null)
                    .Select(s => new { s, Likes = countedLikesUnionedWithNoLikes.First(f => f.Id == s.Id).count });
                if (desc)
                {
                    itemsToReturn = itemsToReturn.OrderByDescending(s => s.Likes);
                }
                else
                {
                    itemsToReturn = itemsToReturn.OrderBy(s => s.Likes);
                }
                return (await itemsToReturn.Select(s=>s.s).Skip(perPage * pageId).Take(perPage).ToListAsync(),
                itemsToReturn.Count());
            }

            var items = _dataContext.BlogItems.Where(i => i.CreatedDate >= fromDate && i.CreatedDate <= toDate).Include(t => t.Likes)
                .Include(t => t.Tags).Include(u => u.User).Where(i => i.BlogItemParentId == null);
            items = OrderItems(orderColumn, desc, items);

            return (await items.Skip(perPage * pageId).Take(perPage).ToListAsync(),
                items.Count());
        }
    }
}
