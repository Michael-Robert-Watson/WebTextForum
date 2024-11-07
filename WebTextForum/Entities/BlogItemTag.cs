using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace WebTextForum.Entities
{
    public class BlogItemTag
    {
        [Key]
        public string Id { get; set; }
        public DateTime CreatedDate { get; set; }
        [ForeignKey("UserId")]
        public virtual IdentityUser User { get; set; }        
        [Required]
        public string UserId { get; set; }
        [ForeignKey("TagId")]
        public Tag Tag { get; set; }
        [Required]
        public string TagId { get; set; }
    }
}
