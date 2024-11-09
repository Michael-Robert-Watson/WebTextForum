using WebTextForum.Entities;
using WebTextForum.Interfaces;
using WebTextForum.ViewModel;

namespace WebTextForum.Helpers
{
    public static class Extensions
    {
        public async static Task<List<BlogItemViewModel>> ToDto(this IEnumerable<BlogItem> items, string userId, ITagsRepository tagRepo)
        {
            var list = new List<BlogItemViewModel>();
            foreach (var item in items)
            {
                var model = new BlogItemViewModel()
                {
                    Id = item.Id,
                    Comment = item.Comment,
                    CreatedDate = item.CreatedDate.ToString("dd MMM yyyy HH:mm"),
                    Likes = item.Likes?.Count() ?? 0,
                    Tags = item.Tags?.Select(s => new NameValue() { Text = s.Tag?.Name, Value = s.TagId.ToString() }).ToList<NameValue>() ?? new List<NameValue>(),
                    User = item.User.UserName ?? "Unknown",
                    LikedByUser = item.Likes.Any(u => u.UserId == userId),
                    AllTags = (await tagRepo.GetTagsAsync()).Select(s => new NameValue() { Text = s.Name, Value = s.Id.ToString() }).ToList<NameValue>() ?? new List<NameValue>(),
                    Replies = new List<BlogItemViewModel>()
                };
                list.Add(model);
            }
            return list;
        }

        public async static Task<BlogItemViewModel> ToDto(this BlogItem item, string userId, ITagsRepository tagRepo)
        {
            var model = new BlogItemViewModel()
            {
                Id = item.Id,
                Comment = item.Comment,
                CreatedDate = item.CreatedDate.ToString("dd MMM yyyy HH:mm"),
                Likes = item.Likes?.Count() ?? 0,
                Tags = item.Tags?.Select(s => new NameValue() { Text = s.Tag.Name, Value = s.TagId.ToString() }).ToList<NameValue>() ?? new List<NameValue>(),
                User = item.User.UserName ?? "Unknown",
                LikedByUser = item.Likes.Any(u => u.UserId == userId),
                AllTags = (await tagRepo.GetTagsAsync()).Select(s => new NameValue() { Text = s.Name, Value = s.Id.ToString() }).ToList<NameValue>() ?? new List<NameValue>(),
                Replies = new List<BlogItemViewModel>()
            };
            return model;
        }
    }
}
