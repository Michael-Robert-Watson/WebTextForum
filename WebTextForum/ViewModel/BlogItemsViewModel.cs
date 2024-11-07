using Microsoft.AspNetCore.Identity;
using System.Security.Principal;
using WebTextForum.Entities;

namespace WebTextForum.ModelView
{
    public class BlogItemsViewModel
    {
        public IIdentity User { get; set; }
        public  List<BlogItem> Items { get; set; }
        public int Count { get; set; }
        public int PageNumber { get; set; }
    }
}
