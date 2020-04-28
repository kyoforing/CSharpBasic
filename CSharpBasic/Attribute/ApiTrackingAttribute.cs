using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;

namespace CSharpBasic.Attribute
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method)]
    public class ApiTrackingAttribute : ActionFilterAttribute
    {
        private readonly ILogger<ApiTrackingAttribute> _logger;

        public ApiTrackingAttribute(ILogger<ApiTrackingAttribute> logger)
        {
            _logger = logger;
        }

        public override void OnActionExecuting(ActionExecutingContext context)
        {
            _logger.LogInformation($"{context.ActionDescriptor.DisplayName}: Request in");
            base.OnActionExecuting(context);
        }

        public override void OnActionExecuted(ActionExecutedContext context)
        {
            base.OnActionExecuted(context);
            var result = context.Result;
            if (result is ObjectResult obj)
            {
                var x = obj.Value;
                _logger.LogInformation($"{context.ActionDescriptor.DisplayName}: Response = {JsonConvert.SerializeObject(x)}");
            }
        }
    }
}