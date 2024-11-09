using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using WebTextForum.Interfaces;
using WebTextForum.Models;
using WebTextForum.ViewModel;

namespace WebTextForum.Controllers
{
    public class ForumController : Controller
    {
        private readonly ILogger<ForumController> _logger;
        private readonly IAppUserService _appUserService;
        private readonly IBlogItemService _blogItemService;

        public ForumController(ILogger<ForumController> logger, IAppUserService appUserService, IBlogItemService blogItemService)
        {
            _logger = logger;
            _appUserService = appUserService;
            _blogItemService = blogItemService;
        }

        [AllowAnonymous]
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            BlogItemsViewModel model = await _blogItemService.GetBlogItemsAsync(0, 20);
            return View(model);
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
            var item = await _blogItemService.GetBlogItemAsync(id, User);
            return new JsonResult(item);
        }
        
        [HttpPatch]
        [Route("Forum/BlogDetailsLike/{id}")]
        public async Task<JsonResult> BlogDetailsLike([FromRoute] string id)
        {
            var item = await _blogItemService.SetBlogItemLikeAsync(id, User);
            return new JsonResult(item);
        }
        
        [HttpPost]
        [Authorize]
        [Route("Forum/BlogDetailsUpdate/{id}")]
        public async Task<JsonResult> BlogDetailsUpdate([FromRoute] string id, string[] tagIds)
        {
            await _blogItemService.UpdateTagsAsync(id, tagIds, User);
            return new JsonResult(true);
        }
        
        [HttpPost]
        [Authorize]
        [Route("Forum/BlogDetailsAddReply/{id}")]
        public async Task<JsonResult> BlogDetailsAddReply([FromRoute] string id, string newComment)
        {
            await _blogItemService.AddReplyAsync(id, User, newComment);
            return new JsonResult(true);
        }
        
        [HttpPost]
        [Authorize]
        public async Task<JsonResult> BlogDetailsAddPost(string newComment)
        {
            await _blogItemService.AddCommentAsync(newComment, User);
            return new JsonResult(true);
        }
    }
}
