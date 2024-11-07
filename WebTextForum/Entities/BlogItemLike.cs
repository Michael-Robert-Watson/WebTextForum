using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebTextForum.Entities
{
    public class BlogItemLike
    {
        [Key]
        public string Id { get; set; }
        public DateTime CreatedDate { get; set; }
        [ForeignKey(nameof(IdentityUser.Id))]
        public string UserId { get; set; }
    }
}
