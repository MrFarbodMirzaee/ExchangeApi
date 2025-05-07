using System.Globalization;

namespace ExchangeApi.Application.Exceptions;

public class ApiExceptions : Exception
{
    // Rise Api Error 
    public ApiExceptions() : base()
    {
    }

    public ApiExceptions(string message) : base(message)
    {
    }

    public ApiExceptions(string message, params object[] args) : base(string.Format(CultureInfo.CurrentCulture,
        message, args))
    {
    }
}