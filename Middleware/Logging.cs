using System;
using System.Web;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;

namespace P2P
{
    // You may need to install the Microsoft.AspNetCore.Http.Abstractions package into your project
    public class Logging
    {
        private readonly RequestDelegate next;
        private readonly IServiceScopeFactory scopeFactory;

        public Logging(RequestDelegate next, IServiceScopeFactory scopeFactory)
        {
            this.scopeFactory = scopeFactory;  
            this.next = next;
        }

        public Task Invoke(HttpContext httpContext)
        {
            System.Diagnostics.Debug.WriteLine(httpContext.Request.Method);
            System.Diagnostics.Debug.WriteLine(httpContext.Request.Path);
            System.Diagnostics.Debug.WriteLine(httpContext.Request.ContentType);     
            return next(httpContext);
        }
    }

    // Extension method used to add the middleware to the HTTP request pipeline.
    public static class MiddlewareExtensions
    {
        public static IApplicationBuilder UseMiddleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<Logging>();
        }
    }
}
