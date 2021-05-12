using CoursesApp.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoursesApp.Middlewares
{
    public class PlayfulMiddleware
    {
        private RequestDelegate _next;

        public PlayfulMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context, IIdService idService)
        {
            var user = context.Request.Headers["User"];
            idService.User = user;

            await _next(context);
        }
    }

    public static class PlayfulMiddlewareExtensions
    {
        public static IApplicationBuilder UsePlayful(this IApplicationBuilder app)
        {
            return app.UseMiddleware<PlayfulMiddleware>();
        }
    }
}
