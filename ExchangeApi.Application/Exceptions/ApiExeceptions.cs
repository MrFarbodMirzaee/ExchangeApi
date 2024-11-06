using System.Globalization;

namespace ExchangeApi.Application.Exceptions;

public class ApiExeceptions : Exception
{
    // Rise Api Error 
    public ApiExeceptions() : base() { }
    public ApiExeceptions(string message) : base(message) { }
    public ApiExeceptions(string message, params object[] args) : base(string.Format(CultureInfo.CurrentCulture, message, args)) { }
}
