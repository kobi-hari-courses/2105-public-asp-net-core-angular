using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Project2Solution.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project2Solution.Middleware
{
    public class CurrentUserMiddleware
    {
        private RequestDelegate _next;

        public CurrentUserMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context, ICurrentUserService currentUser)
        {
            var username = context.Request.Headers["user"].ToString();

            await currentUser.SetCurrentUser(username);
            await _next(context);
        }
    }

    public static class CurrentUserMiddlewareExtension
    {
        public static IApplicationBuilder UseCurrentUser(this IApplicationBuilder app)
        {
            return app.UseMiddleware<CurrentUserMiddleware>();
        }
    }
}
