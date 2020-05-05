using Microsoft.AspNetCore.Http;
using System;
using System.Threading.Tasks;

namespace CSharpBasic.Middlewares
{
    public class AccessRestrictMiddleware
    {
        private const int MaxLimit = 10;
        private readonly RequestDelegate _next;
        private static DateTime _accessTime;
        private static int _accessCount;

        public AccessRestrictMiddleware(RequestDelegate next)
        {
            _next = next;
            _accessTime = DateTime.Now;
        }

        public async Task Invoke(HttpContext context)
        {
            _accessCount++;
            if (IsLimitReset())
            {
                _accessCount = 0;
            }

            if (_accessCount > MaxLimit)
            {
                await context.Response.WriteAsync($"Endpoint access count {_accessCount} over limit rate" +
                                                  $", please wait {(_accessTime - DateTime.UtcNow).Add(TimeSpan.FromMinutes(1))} to retry");
                return;
            }

            await _next(context);
            _accessTime = DateTime.UtcNow;
        }

        private static bool IsLimitReset()
        {
            return _accessTime + TimeSpan.FromMinutes(1) < DateTime.UtcNow;
        }
    }
}