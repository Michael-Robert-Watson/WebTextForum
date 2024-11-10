using System.Security.Principal;
using System.Text.Json.Serialization;
using WebTextForum.Entities;
using WebTextForum.Enums;

namespace WebTextForum.ViewModel
{
    public class BlogItemsViewModel
    {
        public IIdentity User { get; set; }
        public  List<BlogItemViewModel> Items { get; set; }
        public int Count { get; set; }
        public int PageNumber { get; set; }
        public int PerPage { get; set; }
        public bool Searched { get; set; }
        public string FromDate { get; set; }
        public string ToDate { get; set; }
        public bool Desc { get; set; }
        public OrderColumn OrderBy { get; set; }
    }
    public class NameValue()
    {
        [JsonPropertyName("text")]
        public string Text { get; set; }
        [JsonPropertyName("value")]
        public string Value { get; set; }
    }
}
