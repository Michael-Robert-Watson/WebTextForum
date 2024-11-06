using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using WebTextForum.Models;

namespace WebTextForum.Helpers
{
    public class DataContext : IdentityDbContext<AppUser>
    {
        public DataContext() { }

        public DataContext(DbContextOptions<DataContext> options)
             : base(options) { }

        public DbSet<AppUser> AppUsers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            //modelBuilder.Entity<AppUser>().HasData(new AppUser { Name = "admin", Password = Security.HashedPassword("P@55wor$"), Id = 1 });
            modelBuilder.Entity<AppUser>().HasData(new AppUser { UserName = "moderator", Password = Security.HashedPassword("P@55wor$"), IsModerator = true });
            modelBuilder.Entity<AppUser>().HasData(new AppUser { UserName = "user", Password = Security.HashedPassword("P@55wor$")});
        }
    }
}
