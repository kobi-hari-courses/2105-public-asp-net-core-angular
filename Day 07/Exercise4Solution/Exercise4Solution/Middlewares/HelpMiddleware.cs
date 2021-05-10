using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Exercise4Solution.Middlewares
{
    public class HelpMiddleware
    {
        private RequestDelegate _next;
        public HelpMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            await context.Response.WriteAsync(@"<h1>Help for the movies API:</h1>");
            await context.Response.WriteAsync(@"<ul>");
            await context.Response.WriteAsync(@"<li>GET api/movies  - Returns a list of all movies</li>");
            await context.Response.WriteAsync(@"<li>POST api/movies  - Adds a new movie</li>");
            await context.Response.WriteAsync(@"<li>PUT api/movies/index  - replaces the movie in the index</li>");
            await context.Response.WriteAsync(@"<li>DELETE api/movies/index  - deletes a movie in a specific index</li>");
            await context.Response.WriteAsync(@"<li>GET api/movies?startsWith=abc  - Returns a list of all movies with names starting with abc</li>");
            await context.Response.WriteAsync(@"</ul>");
        }
    }

    public static class HelpMiddlewareExtensions
    {
        public static IApplicationBuilder UseHelp(this IApplicationBuilder app)
        {
            app.Map("/help", builder =>
            {
                builder.UseMiddleware<HelpMiddleware>();
            });
            return app;
        }
    }
}
