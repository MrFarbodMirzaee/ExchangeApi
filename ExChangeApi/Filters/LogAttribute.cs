using Microsoft.AspNetCore.Mvc.Filters;

namespace ExchangeApi.Filters;

public class LogAttribute : Attribute, IActionFilter
{
    public LogAttribute()
    {
    }

    public void OnActionExecuted(ActionExecutedContext context)
    {
        Console.WriteLine($"Action Method {context.ActionDescriptor} Executing at");
    }

    public void OnActionExecuting(ActionExecutingContext context)
    {
        Console.WriteLine($"Action Method {context.ActionDescriptor} Executed at ");
    }

    public bool AllowMultiple => true;
}