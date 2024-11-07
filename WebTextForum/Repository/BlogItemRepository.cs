﻿using Microsoft.EntityFrameworkCore;
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

        public async Task<BlogItem> GetBlogItemAsync(string id)
        {
            return await _dataContext.BlogItems.Include(t => t.Likes).Include(t => t.Tags).ThenInclude(t=>t.Tag).Include(u => u.User)
                .FirstOrDefaultAsync(i=>i.Id==id);
        }

        public async Task<(IEnumerable<BlogItem>, int)> GetBlogItemsAsync(int pageId, int perPage)
        {
            var item = _dataContext.BlogItems.Include(t => t.Likes).Include(t => t.Tags).Include(u => u.User).Where(i => i.BlogItemParentId == null);

            return (await item.Include(t => t.Tags).Skip(perPage * pageId).Take(perPage).ToListAsync(),
                item.Count());
        }

        public async Task SaveChangesAsync()
        {
            await _dataContext.SaveChangesAsync();
        }
    }
}
