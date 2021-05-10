using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FunWithMiddleware.Middlewares
{
    public class AdditionMiddleware
    {
        private RequestDelegate _next;

        public AdditionMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            var url = context.Request.Path.ToString();
            var result = url
                .Split("/")
                .Where(s => !string.IsNullOrWhiteSpace(s))
                .Select(str => int.Parse(str))
                .Sum();

            await context.Response.WriteAsync("The answer is " + result);
        }
    }

    public static class AdditionMiddlewareExtensions 
    {
        public static IApplicationBuilder UseAddition(this IApplicationBuilder app)
        {
            app.Map("/add", builder =>
            {
                builder.UseMiddleware<AdditionMiddleware>();
            });
            return app;
        }
    }
}
