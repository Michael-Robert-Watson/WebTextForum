using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebTextForum.Filters;
using WebTextForum.Interfaces;

namespace WebTextForum.Controllers
{
    [AuthorizationFilter]
    public class ApiController : Controller
    {
        private readonly ILogger<ForumController> _logger;
        private readonly IAppUserService _appUserService;
        private readonly IBlogItemService _blogItemService;


        public ApiController(ILogger<ForumController> logger, IAppUserService appUserService, IBlogItemService blogItemService)
        {
            _logger = logger;
            _appUserService = appUserService;
            _blogItemService = blogItemService;
        }

        public async Task<JsonResult> GetAllPosts()
        {
            var items = await _blogItemService.GetBlogItemsAsync(0, int.MaxValue);
            return new JsonResult(items);
        }

        public async Task<JsonResult> GetPagedPosts(int page, int perPage)
        {
            var items = await _blogItemService.GetBlogItemsAsync(page, perPage);
            return new JsonResult(items);
        }

        [HttpGet]
        [Route("Api/BlogDetails/{id}")]
        public async Task<JsonResult> BlogDetails([FromRoute] string id)
        {
            var item = await _blogItemService.GetBlogItemAsync(id, null);
            return new JsonResult(item);
        }

        [HttpPatch]
        [Route("Api/BlogDetailsLike/{id}")]
        public async Task<JsonResult> BlogDetailsLike([FromRoute] string id, string userId)
        {
            try
            {
                var item = await _blogItemService.SetBlogItemLikeAsync(id, userId);
                return new JsonResult(item);
            }
            catch (Exception ex)
            {
                _logger.LogError("Error blog details Like for Item id: {@id} {@ex}", id, ex);
                throw;
            }
        }

        [HttpPost]
        [Route("Api/BlogDetailsUpdate/{id}")]
        public async Task<JsonResult> BlogDetailsUpdate([FromRoute] string id, string[] tagIds, string userId)
        {
            try
            {
                await _blogItemService.UpdateTagsAsync(id, tagIds, userId);
                return new JsonResult(true);
            }
            catch (Exception ex)
            {
                _logger.LogError("Error updating blog details for Item id: {@id} {ex}", id, ex);
                throw;
            }
        }

        [HttpPost]
        [Route("Api/BlogDetailsAddReply/{id}")]
        public async Task<JsonResult> BlogDetailsAddReply([FromRoute] string id, string newComment, string userId)
        {
            try
            {
                await _blogItemService.AddReplyAsync(id, userId, newComment);
                return new JsonResult(true);
            }
            catch (Exception ex)
            {
                _logger.LogError("Error adding reply to blog for Item id: {@id} {@ex}", id, ex);
                throw;
            }
        }

        [HttpPost]
        public async Task<JsonResult> BlogDetailsAddPost(string newComment, string userId)
        {
            try
            {
                await _blogItemService.AddCommentAsync(newComment, userId);
                return new JsonResult(true);
            }
            catch (Exception ex)
            {
                _logger.LogError("Error adding post to blog {@ex}", ex);
                throw;
            }
        }
    }
}
