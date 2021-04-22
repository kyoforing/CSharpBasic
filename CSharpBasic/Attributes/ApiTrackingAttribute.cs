using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Logging;

namespace CSharpBasic.Attributes
{
    public class ApiTrackingAttribute : IActionFilter
    {
        private ILogger<ApiTrackingAttribute> _logger;

        public ApiTrackingAttribute(ILogger<ApiTrackingAttribute> logger)
        {
            _logger = logger;
        }
        public void OnActionExecuting(ActionExecutingContext context)
        {
            _logger.LogInformation("Before call");
        }
        public void OnActionExecuted(ActionExecutedContext context)
        {
            _logger.LogInformation("After call");
        }
    }
}