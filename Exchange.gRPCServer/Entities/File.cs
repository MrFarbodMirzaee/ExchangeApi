namespace Exchange.gRPCServer.Entities;
public class File
{
    public int Id { get; set; }
    public string FileName { get; set; }
    public byte[] Content { get; set; }
    public long Size { get; set; }
}
