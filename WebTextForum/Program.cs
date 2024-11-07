using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Authorization;
using WebTextForum.Helpers;
using WebTextForum.Interfaces;
using WebTextForum.Repository;
using WebTextForum.Services;

namespace WebTextForum
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            var services = builder.Services;

            ConfigureServices(services);
            
            var app = builder.Build();

            // migrate any database changes on startup (includes initial db creation)
            using (var scope = app.Services.CreateScope())
            {
                var dataContext = scope.ServiceProvider.GetRequiredService<DataContext>();
                dataContext.Database.EnsureCreated();
            }

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Forum/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Account}/{action=Login}");

            app.Run();
        }

        private static void ConfigureServices(IServiceCollection services)
        {
            services.AddSqlite<DataContext>("DataSource=WebTextForum.db");
            services.AddTransient<IBlogItemService, BlogItemService>();
            services.AddTransient<IAppUserService, AppUserService>();
            services.AddTransient<IBlogItemsRepository, BlogItemRepository>();
            services.AddTransient<ITagsRepository, TagsRepository>();

            services.AddAuthorization();
            services.AddAuthentication().AddCookie(IdentityConstants.ApplicationScheme);
            services.AddIdentityCore<IdentityUser>().AddEntityFrameworkStores<DataContext>()
                .AddApiEndpoints();
            services.AddDbContext<DataContext>();

            services.AddControllersWithViews(config =>
            {
                var policy = new AuthorizationPolicyBuilder()
                                 .RequireAuthenticatedUser()
                                 .Build();
                config.Filters.Add(new AuthorizeFilter(policy));
            });
        }
    }
}
