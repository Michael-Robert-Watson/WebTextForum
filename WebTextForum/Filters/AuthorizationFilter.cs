using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc;

namespace WebTextForum.Filters
{
    public class AuthorizationFilter : Attribute, IAsyncAuthorizationFilter
    {
        public async Task OnAuthorizationAsync(AuthorizationFilterContext context)
        {
            var authRequest = context.HttpContext.Request.Headers.Authorization;
            if (!authRequest.Any(a => a.Equals("Bearer WebTextForumSecretKey!!@@=")))
            {
                context.Result = new UnauthorizedResult();
                return;
            }
        }
    }
}