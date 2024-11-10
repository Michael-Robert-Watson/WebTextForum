using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
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
            try
            {
                var items = await _blogItemService.GetBlogItemsAsync(0, int.MaxValue, Enums.OrderColumn.Date, false);
                return new JsonResult(items);
            }
            catch (Exception ex)
            {
                _logger.LogError("Error getting all posts {@ex}", ex);
                throw new Exception(ex.Message);
            }
        }

        public async Task<JsonResult> GetPagedPosts(int page, int perPage)
        {
            try
            {
                var items = await _blogItemService.GetBlogItemsAsync(page, perPage, Enums.OrderColumn.Date, false);
                return new JsonResult(items);
            }
            catch (Exception ex)
            {
                _logger.LogError("Error getting paged posts: [age-{@page} perpage-{@perPage} {@ex}", page, perPage, ex);
                throw new Exception(ex.Message);
            }
            
        }

        [HttpGet]
        [Route("Api/BlogDetails/{id}")]
        public async Task<JsonResult> BlogDetails([FromRoute] string id)
        {
            try
            {
                var item = await _blogItemService.GetBlogItemAsync(id, null);
                return new JsonResult(item);
            }
            catch (Exception ex)
            {
                _logger.LogError("Error blog details for Item id: {@id} {@ex}", id, ex);
                throw new Exception(ex.Message);
            }
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
                throw new Exception(ex.Message);
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
                throw new Exception(ex.Message);
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
                throw new Exception(ex.Message);
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
                throw new Exception(ex.Message);
            }
        }
    }
}
