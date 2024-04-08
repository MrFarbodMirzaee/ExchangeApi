using Microsoft.AspNetCore.Mvc.Filters;

namespace ExchangeApi.Filters;

public class LogAttribute : Attribute, IActionFilter
{

    public LogAttribute()
    {

    }

    public void OnActionExecuted(ActionExecutedContext context)
    {
        Console.WriteLine(string.Format("Action Method {0} Exequting at {1}", context.ActionDescriptor));
    }

    public void OnActionExecuting(ActionExecutingContext context)
    {
        Console.WriteLine(string.Format("Action Method {0} Exequted at {1}", context.ActionDescriptor));
    }
    public bool AllowMultiple
    {
        get { return true; }
    }
}
