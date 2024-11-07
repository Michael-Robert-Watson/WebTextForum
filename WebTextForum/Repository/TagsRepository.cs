using Microsoft.EntityFrameworkCore;
using WebTextForum.Entities;
using WebTextForum.Helpers;
using WebTextForum.Interfaces;

namespace WebTextForum.Repository
{
    public class TagsRepository : ITagsRepository
    {
        private readonly DataContext _dataContext;

        public TagsRepository(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public async Task<IEnumerable<Tag>> GetTagsAsync()
        {
            return await _dataContext.Tags.ToListAsync();
        }
    }
}
