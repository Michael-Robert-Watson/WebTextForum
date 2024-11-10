using NSubstitute;
using WebTextForum.Entities;
using WebTextForum.Enums;
using WebTextForum.Interfaces;
using WebTextForum.Services;

namespace XUnitTests.Services
{
    public class BlogItemServiceTests
    {
        [Test]
        public async Task AddCommentAsync_WhenCalled_ShouldHitTheDb()
        {
            //assign
            var blogRepo = Substitute.For<IBlogItemsRepository>();
            var tagRepo = Substitute.For<ITagsRepository>();

            var svc = new BlogItemService(blogRepo, tagRepo);

            //act
            await svc.AddCommentAsync("comment", "userId");

            //assert
            await blogRepo.Received(1).AddBlogItemsAsync(Arg.Any<BlogItem>());
        }
        [Test]
        public async Task AddReplyAsync_WhenCalled_ShouldHitTheDb()
        {
            //assign
            var blogRepo = Substitute.For<IBlogItemsRepository>();
            var tagRepo = Substitute.For<ITagsRepository>();

            var svc = new BlogItemService(blogRepo, tagRepo);

            //act
            await svc.AddReplyAsync("id", "comment", "userId");

            //assert
            await blogRepo.Received(1).AddBlogItemsAsync(Arg.Any<BlogItem>());
        }

        [Test]
        public async Task GetBlogItemAsync_WhenHasItem_ShouldReturnItem()
        {
            //assign
            var itemId = "46664";
            var blogRepo = Substitute.For<IBlogItemsRepository>();
            blogRepo.GetBlogItemAsync(Arg.Any<string>()).Returns(Task.FromResult<BlogItem>(new BlogItem()
            {
                Id = itemId,
                Likes = new List<BlogItemLike>(),
                User = new Microsoft.AspNetCore.Identity.IdentityUser()
            }));
            var tagRepo = Substitute.For<ITagsRepository>();
            tagRepo.GetTagsAsync().Returns(Task.FromResult<IEnumerable<Tag>>(new List<Tag>()));

            var svc = new BlogItemService(blogRepo, tagRepo);

            //act
            var item = await svc.GetBlogItemAsync("id", null);

            //assert
            Assert.That(item.Id, Is.EqualTo(itemId));
        }

        [Test]
        public async Task GetBlogItemAsync_WhenItemNotAvailable_ShouldThrowException()
        {
            //assign
            var blogRepo = Substitute.For<IBlogItemsRepository>();
            var tagRepo = Substitute.For<ITagsRepository>();
            tagRepo.GetTagsAsync().Returns(Task.FromResult<IEnumerable<Tag>>(new List<Tag>()));

            var svc = new BlogItemService(blogRepo, tagRepo);

            //act & assert
            Assert.ThrowsAsync<Exception>(() => svc.GetBlogItemAsync("id", null));
        }

        [Test]
        public async Task SetBlogItemLikeAsync_WhenUserHasAlreadyLiked_ShouldRemoveTheLike()
        {
            //assign
            var blogRepo = Substitute.For<IBlogItemsRepository>();
            blogRepo.GetBlogItemAsync(Arg.Any<string>()).Returns(Task.FromResult<BlogItem>(new BlogItem()
            {
                Id = "id",
                Likes = new List<BlogItemLike>() { new BlogItemLike() { UserId = "userid" } },
                User = new Microsoft.AspNetCore.Identity.IdentityUser()
            }));
            var tagRepo = Substitute.For<ITagsRepository>();
            tagRepo.GetTagsAsync().Returns(Task.FromResult<IEnumerable<Tag>>(new List<Tag>()));

            var svc = new BlogItemService(blogRepo, tagRepo);

            //act
            var item = await svc.SetBlogItemLikeAsync("id", "userid");

            // Assert
            Assert.That(item.Likes, Is.EqualTo(0));
        }

        [Test]
        public async Task SetBlogItemLikeAsync_WhenUserHasNotAlreadyLiked_ShouldAddTheLike()
        {
            //assign
            var blogRepo = Substitute.For<IBlogItemsRepository>();
            blogRepo.GetBlogItemAsync(Arg.Any<string>()).Returns(Task.FromResult<BlogItem>(new BlogItem()
            {
                Id = "id",
                Likes = new List<BlogItemLike>() { new BlogItemLike() { UserId = "useridSOMEBODYDIFERENT" } },
                User = new Microsoft.AspNetCore.Identity.IdentityUser()
            }));
            var tagRepo = Substitute.For<ITagsRepository>();
            tagRepo.GetTagsAsync().Returns(Task.FromResult<IEnumerable<Tag>>(new List<Tag>()));

            var svc = new BlogItemService(blogRepo, tagRepo);

            //act
            var item = await svc.SetBlogItemLikeAsync("id", "userid");

            // Assert
            Assert.That(item.Likes, Is.EqualTo(2));
        }

        [Test]
        public async Task GetBlogItemsAsync_WhenHasItems_ShouldReturnItems()
        {
            //assign
            var blogRepo = Substitute.For<IBlogItemsRepository>();
            var list = new List<BlogItem>() {
                new BlogItem()
                {
                    Id = "1",
                    Likes = new List<BlogItemLike>(),
                    User = new Microsoft.AspNetCore.Identity.IdentityUser()
                },
                new BlogItem()
                {
                    Id = "2",
                    Likes = new List<BlogItemLike>(),
                    User = new Microsoft.AspNetCore.Identity.IdentityUser()
                } };
            int count = 46664;

            blogRepo.GetBlogItemsAsync(Arg.Any<int>(), Arg.Any<int>(), Arg.Any<OrderColumn>(), Arg.Any<bool>()).Returns(Task.FromResult<(IEnumerable<BlogItem>, int)>((list,count)));
            var tagRepo = Substitute.For<ITagsRepository>();
            tagRepo.GetTagsAsync().Returns(Task.FromResult<IEnumerable<Tag>>(new List<Tag>()));

            var svc = new BlogItemService(blogRepo, tagRepo);

            //act
            var items = await svc.GetBlogItemsAsync(0,10, WebTextForum.Enums.OrderColumn.Date, true);

            //assert
            Assert.That(items.Items.Count, Is.EqualTo(2));
            Assert.That(items.Count, Is.EqualTo(count));
        }

    }
}
