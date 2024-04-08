namespace ExchangeApi.MiddelWare;

public class LogUrlMiddleWare
{
    private readonly RequestDelegate _Next;
    private readonly ILogger<LogUrlMiddleWare> _logger;
    public LogUrlMiddleWare(ILogger<LogUrlMiddleWare> logger,RequestDelegate next) 
    {
        _logger = logger;
        _Next = next;
    }
    public async Task InvokeAsync(HttpContext context)
    {
        _logger.LogInformation($"Request Url:{Microsoft.AspNetCore.Http.Extensions.UriHelper.GetDisplayUrl(context.Request)}");
        await this._Next(context);
    }   
}
public static class LogUrlExtention
{
    public static IApplicationBuilder UseLogUrl(this IApplicationBuilder app)
    {
        return app.UseMiddleware<LogUrlMiddleWare>();
    }
}