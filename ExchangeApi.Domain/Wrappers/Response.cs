namespace ExchangeApi.Domain.Wrappers;

/// <summary>
/// Represents a standardized response pattern for API responses.
/// This class encapsulates success status, message, data, and potential error messages.
/// </summary>
/// <typeparam name="T">The type of the data being returned in the response.</typeparam>
public class Response<T>
{
    /// <summary>
    /// Initializes a new instance of the <see cref="Response{T}"/> class.
    /// </summary>
    public Response()
    {
        Errors = new List<string>();
    }

    /// <summary>
    /// Initializes a failed response with a formatted message and no data.
    /// </summary>
    /// <param name="message">The message format string describing the error or outcome.</param>
    /// <param name="args">Optional arguments to be formatted into the message string.</param>
    public Response(string message, params object[] args)
    {
        Succeeded = false;
        Message = string.Format(message, args);
        Data = default!;
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="Response{T}"/> class with data and an optional message.
    /// </summary>
    /// <param name="data">The data to return in the response.</param>
    /// <param name="message">An optional message about the response.</param>
    public Response(T data, string message = null)
    {
        Succeeded = true;
        Message = message;
        Data = data;
        Errors = new List<string>();
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="Response{T}"/> class with a failure message.
    /// </summary>
    /// <param name="message">The message indicating the failure reason.</param>
    public Response(string message)
    {
        Message = message;
        Succeeded = false;
        Errors = new List<string>();
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="Response{T}"/> class with data.
    /// </summary>
    /// <param name="data">The data to return in the response.</param>
    public Response(T data)
    {
        Data = data;
        Succeeded = true;
        Errors = new List<string>();
    }

    /// <summary>
    /// Gets or sets a value indicating whether the operation succeeded.
    /// </summary>
    public bool Succeeded { get; set; }

    /// <summary>
    /// Gets or sets the message associated with the response.
    /// </summary>
    public string Message { get; set; }

    /// <summary>
    /// Gets or sets the data returned in the response.
    /// </summary>
    public T Data { get; set; }

    /// <summary>
    /// Gets or sets a list of error messages, if any.
    /// </summary>
    public List<string> Errors { get; set; }
}