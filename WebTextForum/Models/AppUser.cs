using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace WebTextForum.Models
{
    public class AppUser : IdentityUser
    {
        [Required]
        public string Password { get; set; }
        public bool IsModerator { get; set; }
    }
}
