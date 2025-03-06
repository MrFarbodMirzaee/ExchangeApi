namespace Exchange.gRPCServer.Entities;

public class HttpStatusCodeException(int statusCode, string message) : Exception(message)
{
    public int StatusCode { get; } = statusCode;
}