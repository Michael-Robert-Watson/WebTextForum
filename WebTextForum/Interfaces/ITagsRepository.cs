using WebTextForum.Entities;

namespace WebTextForum.Interfaces
{
    public interface ITagsRepository
    {
        Task<IEnumerable<Tag>> GetTagsAsync();
    }
}
