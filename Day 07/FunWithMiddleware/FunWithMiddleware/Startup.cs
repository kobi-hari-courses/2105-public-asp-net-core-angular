using FunWithMiddleware.Middlewares;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FunWithMiddleware
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
        }

        private async Task _middleware3(HttpContext context, Func<Task> next)
        {
            await context.Response.WriteAsync(@"<h4>I am middleware 3</h4>");
            await next();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseExceptionHandler("/Error");

            app.UseAddition();

            app.Use(async (context, next) =>
            {
                await context.Response.WriteAsync(@"<h1>Good Morning</h1>");
                await context.Response.WriteAsync($"your url is: {context.Request.Path}");

                if (context.Request.Path.ToString().Contains("bla")) return;

                await next();

                await context.Response.WriteAsync("@<hr> <h1>Have a good day</h1>");
            });

            app.Use(_middleware3);

            app.Run(async context =>
            {
                await context.Response.WriteAsync(@"<h2>Hello Fun with Middleware</h2>");
            });

            //if (env.IsDevelopment())
            //{
            //    app.UseDeveloperExceptionPage();
            //}

            //app.UseRouting();

            //app.UseEndpoints(endpoints =>
            //{
            //    endpoints.MapGet("/", async context =>
            //    {
            //        await context.Response.WriteAsync("Hello World!");
            //    });
            //});
        }
    }
}
