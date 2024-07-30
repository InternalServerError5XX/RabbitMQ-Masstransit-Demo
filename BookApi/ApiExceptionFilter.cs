using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc;
using MassTransit;

namespace BookApi
{
    public class ApiExceptionFilter(IPublishEndpoint publishEndpoint) : IAsyncExceptionFilter
    {
        public async Task OnExceptionAsync(ExceptionContext context)
        {
            var errorMessage = new
            {
                Error = context.Exception.Message,
                StackTrace = context.Exception.StackTrace
            };

            context.Result = new BadRequestObjectResult(errorMessage);
            context.ExceptionHandled = true;
        }
    }
}
