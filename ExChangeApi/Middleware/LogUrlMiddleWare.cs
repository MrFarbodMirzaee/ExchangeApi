namespace ExchangeApi.Middleware;

public class LogUrlMiddleWare(ILogger<LogUrlMiddleWare> logger, RequestDelegate next)
{
    public async Task InvokeAsync(HttpContext context)
    {
        logger.LogInformation(
            $"Request Url:{Microsoft.AspNetCore.Http.Extensions.UriHelper.GetDisplayUrl(context.Request)}");
        await next(context);
    }
}

public static class LogUrlExtension
{
    public static IApplicationBuilder UseLogUrl(this IApplicationBuilder app)
    {
        return app.UseMiddleware<LogUrlMiddleWare>();
    }
}