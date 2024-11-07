using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace WebTextForum.Entities
{
    public class BlogItemTag
    {
        [Key]
        public int Id { get; set; }
        public DateTime CreatedDate { get; set; }
        [ForeignKey("UserId")]
        public virtual IdentityUser User { get; set; }        
        [Required]
        public string UserId { get; set; }
        [ForeignKey("TagId")]
        public BlogItemTag Tag { get; set; }
        [Required]
        public int TagId { get; set; }
    }
}
