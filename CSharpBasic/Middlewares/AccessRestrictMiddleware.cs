using Microsoft.AspNetCore.Http;
using System;
using System.Threading.Tasks;

namespace CSharpBasic.Middlewares
{
    public class AccessRestrictMiddleware
    {
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
            if (IsLimitReset())
            {
                _accessCount = 0;
                await _next(context);
            }
            else
            {
                if (_accessCount <= 3)
                {
                    await _next(context);
                    _accessTime = DateTime.UtcNow;
                }
                else
                {
                    await context.Response.WriteAsync($"Endpoint access count {_accessCount} over limit 3 times/min" +
                                                $", please wait {(_accessTime - DateTime.UtcNow).Add(TimeSpan.FromMinutes(1))} to retry");
                }
            }
            _accessCount++;
        }

        private static bool IsLimitReset()
        {
            return _accessTime + TimeSpan.FromMinutes(1) < DateTime.UtcNow;
        }
    }
}