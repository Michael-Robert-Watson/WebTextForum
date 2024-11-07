using System.ComponentModel.DataAnnotations;

namespace WebTextForum.Entities
{
    public class Tag
    {
        [Key]
        public string Id { get; set; }
        [Required]
        public string Name { get; set; }
    }
}
