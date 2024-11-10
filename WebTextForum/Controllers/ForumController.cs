using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using WebTextForum.Enums;
using WebTextForum.Interfaces;
using WebTextForum.Models;
using WebTextForum.ViewModel;

namespace WebTextForum.Controllers
{
    public class ForumController : Controller
    {
        private readonly ILogger<ForumController> _logger;
        private readonly IBlogItemService _blogItemService;
        private const int pageSize = 5; // should be in config...!

        public ForumController(ILogger<ForumController> logger, IBlogItemService blogItemService)
        {
            _logger = logger;
            _blogItemService = blogItemService;
        }

        [AllowAnonymous]
        [HttpGet]
        public async Task<IActionResult> Index(int? page, DateTime? fromDate, DateTime? toDate, OrderColumn? orderBy, bool? desc)
        {
            try
            {
                if (page < 0)
                {
                    page = 0;
                }

                BlogItemsViewModel model = null;
                if (fromDate != null && toDate != null)
                {
                    model = await _blogItemService.SearchBlogItemsAsync(page.GetValueOrDefault(0), pageSize, fromDate.Value, toDate.Value, orderBy.GetValueOrDefault(0), desc.GetValueOrDefault(true));
                    model.Searched = true;
                    model.FromDate = fromDate.Value.ToString("dd-MMM-yyyy");
                    model.ToDate = toDate.Value.ToString("dd-MMM-yyyy");
                }
                else
                {
                    model = await _blogItemService.GetBlogItemsAsync(page.GetValueOrDefault(0), pageSize, orderBy.GetValueOrDefault(OrderColumn.Date), desc.GetValueOrDefault());
                }

                model.OrderBy = orderBy.GetValueOrDefault(0);
                model.Desc = desc.GetValueOrDefault(true);
                return View(model);
            }
            catch (Exception ex)
            {
                _logger.LogError("Error getting Index {@ex}", ex);
                throw;
            }
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        [HttpGet]
        [Route("Forum/BlogDetails/{id}")]
        public async Task<JsonResult> BlogDetails([FromRoute] string id)
        {
            try
            {
                var item = await _blogItemService.GetBlogItemAsync(id, User);
                return new JsonResult(item);
            }
            catch (Exception ex)
            {
                _logger.LogError("Error getting details for Item id: {@id} {@ex}", id, ex);
                throw;
            }
        }

        [HttpPatch]
        [Route("Forum/BlogDetailsLike/{id}")]
        public async Task<JsonResult> BlogDetailsLike([FromRoute] string id)
        {
            try
            {
                var item = await _blogItemService.SetBlogItemLikeAsync(id, User);
                return new JsonResult(item);
            }
            catch (Exception ex)
            {
                _logger.LogError("Error blog details Like for Item id: {@id} {@ex}", id, ex);
                throw;
            }
        }

        [HttpPost]
        [Authorize]
        [Route("Forum/BlogDetailsUpdate/{id}")]
        public async Task<JsonResult> BlogDetailsUpdate([FromRoute] string id, string[] tagIds)
        {
            try
            {
                await _blogItemService.UpdateTagsAsync(id, tagIds, User);
                return new JsonResult(true);
            }
            catch (Exception ex)
            {
                _logger.LogError("Error updating blog details for Item id: {@id} {ex}", id, ex);
                throw;
            }
        }

        [HttpPost]
        [Authorize]
        [Route("Forum/BlogDetailsAddReply/{id}")]
        public async Task<JsonResult> BlogDetailsAddReply([FromRoute] string id, string newComment)
        {
            try
            {
                await _blogItemService.AddReplyAsync(id, User, newComment);
                return new JsonResult(true);
            }
            catch (Exception ex)
            {
                _logger.LogError("Error adding reply to blog for Item id: {@id} {@ex}", id, ex);
                throw;
            }
        }

        [HttpPost]
        [Authorize]
        public async Task<JsonResult> BlogDetailsAddPost(string newComment)
        {
            try
            {
                await _blogItemService.AddCommentAsync(newComment, User);
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
