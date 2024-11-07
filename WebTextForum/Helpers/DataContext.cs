﻿using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using WebTextForum.Entities;
using WebTextForum.Models;

namespace WebTextForum.Helpers
{
    public class DataContext : IdentityDbContext<IdentityUser>
    {
        public UserManager<IdentityUser> _userManager;
        public RoleManager<IdentityRole> _roleManager;

        public DbSet<BlogItem> BlogItems { get; set; }
        public DbSet<Tag> Tags{ get; set; }
        public DbSet<BlogItemLike> BlogItemLikes { get; set; }
        public DbSet<BlogItemTag> BlogItemTags { get; set; }

        public DataContext(DbContextOptions<DataContext> options)
             : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Tag>().HasData(
                new Tag
                {
                    Id = Guid.NewGuid().ToString(),
                    Name = "Misleading or False Information"
                },
                new Tag
                {
                    Id = Guid.NewGuid().ToString(),
                    Name = "News"
                },
                new Tag
                {
                    Id = Guid.NewGuid().ToString(),
                    Name = "Personal"
                },
                new Tag
                {
                    Id = Guid.NewGuid().ToString(),
                    Name = "Code"
                });

            //a hasher to hash the password before seeding the user to the db
            var hasher = new PasswordHasher<IdentityUser>();

            var name = "Moderator";
            var password = "password";
            string moderatorRoleId = createRole(modelBuilder, name);
            CreateUser(modelBuilder, hasher, moderatorRoleId, name, password, $"{name}1@mail.com");

            name = "User";
            string userRoleId = createRole(modelBuilder, name);
            CreateUser(modelBuilder, hasher, userRoleId, $"{name}1", password, $"{name}1@mail.com");
            CreateUser(modelBuilder, hasher, userRoleId, $"{name}2", password, $"{name}2@mail.com");
            CreateUser(modelBuilder, hasher, userRoleId, $"{name}3", password, $"{name}3@mail.com");
            CreateUser(modelBuilder, hasher, userRoleId, $"{name}4", password, $"{name}4@mail.com");
        }

        private static void CreateUser(ModelBuilder modelBuilder, PasswordHasher<IdentityUser> hasher, string UserRoleId, string name, string password, string email)
        {
            //Seeding the User to AspNetUsers table
            string userId = Guid.NewGuid().ToString();
            var user = new IdentityUser
            {
                Id = userId,
                UserName = name,
                NormalizedUserName = name.ToUpper(),
                Email = email,
                PasswordHash = hasher.HashPassword(null, password)
            };
            modelBuilder.Entity<IdentityUser>().HasData(
              user
            );


            //Seeding the relation between our user and role to AspNetUserRoles table
            modelBuilder.Entity<IdentityUserRole<string>>().HasData(
                new IdentityUserRole<string>
                {
                    RoleId = UserRoleId,
                    UserId = user.Id
                }
            );
        }

        private static string createRole(ModelBuilder modelBuilder, string name)
        {
            var role = new IdentityRole
            {
                Name = name,
                NormalizedName = name.ToUpper()
            };
            modelBuilder.Entity<IdentityRole>().HasData(role);
            return role.Id;
        }
    }
}
