using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc;
using MassTransit;

namespace BookApi
{
    public class ApiExceptionFilter(IPublishEndpoint publishEndpoint, ILogger<ApiExceptionFilter> logger) : IAsyncExceptionFilter
    {
        public async Task OnExceptionAsync(ExceptionContext context)
        {
            var errorMessage = new
            {
                Error = context.Exception.Message,
                StackTrace = context.Exception.StackTrace
            };

            logger.LogError($"Error: {errorMessage}");
            context.Result = new BadRequestObjectResult(errorMessage);
            context.ExceptionHandled = true;
        }
    }
}
