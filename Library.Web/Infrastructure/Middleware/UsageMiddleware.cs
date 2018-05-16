using System.Threading.Tasks;
using Library.Services;
using Microsoft.AspNetCore.Http;

namespace Library.Web.Infrastructure.Middleware
{
    public class UsageMiddleware
    {
        private readonly RequestDelegate _next;

        public UsageMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext httpContext, ILibrarian librarian) // injection to method
        {
            httpContext.Items["CurrentUserName"] = httpContext.User.Identity.Name;
            
            await librarian.CheckAccess();
            
            await _next(httpContext);
        }
    }
}