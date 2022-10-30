using Microsoft.AspNetCore.Mvc.Filters;

namespace ProjectService.Filter;

public class ExceptionFilter : IExceptionFilter
{
    public void OnException(ExceptionContext context)
    {
        context.HttpContext.Response.StatusCode = 501;
        context.HttpContext.Response.WriteAsync("Exception Filter returns");
    }
}