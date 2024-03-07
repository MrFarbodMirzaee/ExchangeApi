using Microsoft.AspNetCore.Mvc.Filters;

namespace ExchangeApi.Filter;

public class LogAttribute
{
    public void onActionExecuting(ActionExecutingContext context)
    {
        Console.WriteLine(string.Format("ActionMethod{0} excuting at{1} ", context.ActionDescriptor));
    }
    public void onActionExecuted(ActionExecutedContext context)
    {
        Console.WriteLine(string.Format("ActionMethod{0} excuting at{1} ", context.ActionDescriptor));
    }
    public bool AllowMultiple
    {
        get { return true; }
    }
}
