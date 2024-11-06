namespace ExchangeApi.Domain.Wrappers;
//Response Pattern return succeeded ,Message Data ,List<Errors>
public class Response<T>
{
    public Response()
    {

    }
    public Response(T data, string message = null)
    {
        Succeeded = true;
        Message = message;
        Data = data;
    }
    public Response(string message)
    {
        Message = message;
        Succeeded = false;
    }
    public Response(T data)
    {
        Data = data;
        Succeeded = true;
    }
    public bool Succeeded { get; set; }
    public string Message { get; set; }
    public T Data { get; set; }
    public List<string> Errors { get; set; }
}
