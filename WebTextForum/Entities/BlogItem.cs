using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebTextForum.Entities
{
    public class BlogItem
    {
        [Key]
        public int Id { get; set; }
        public DateTime CreatedDate { get; set; }
        public virtual IdentityUser User { get; set; }
        [ForeignKey(nameof(IdentityUser.Id))]
        [Required]
        public string UserId { get; set; }
        public string Comment { get; set; }
        [ForeignKey("BlogItemParentId")]
        public virtual BlogItem BlogItemParent { get; set; }
        public int? BlogItemParentId { get; set; }
        public ICollection<BlogItemLike> Likes { get; set; }
        public ICollection<BlogItemTag> Tags { get; set; }
    }
}
