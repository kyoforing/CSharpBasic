using CSharpBasic.Middlewares;
using Microsoft.AspNetCore.Builder;

namespace CSharpBasic.Extensions
{
    public static class ApplicationBuilderExtensions
    {
        public static IApplicationBuilder UseAccessRestrict(
            this IApplicationBuilder app)
        {
            return app.UseMiddleware<AccessRestrictMiddleware>();
        }
    }
}