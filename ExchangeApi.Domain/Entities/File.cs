#nullable disable
namespace ExchangeApi.Domain.Entities;
public class File
{
    public int Id { get; set; }
    public string FileName { get; set; }
    public string ContentType { get; set; }
    public byte[] FileData { get; set; }
}
