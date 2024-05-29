
using Exchange.gRPCServer.Protos;
using Google.Protobuf.WellKnownTypes;
using Grpc.Core;

namespace Exchange.gRPCServer.Services;

public class CurrencyImageFileStreamingService : CurrencyFileStreaming.CurrencyFileStreamingBase
{
    private readonly IWebHostEnvironment _webHostEnvironment;
    private string _filePath;
    public CurrencyImageFileStreamingService(IWebHostEnvironment webHostEnvironment) 
    {
        _webHostEnvironment = webHostEnvironment;
        _filePath = Path.Combine(_webHostEnvironment.ContentRootPath, "files");
        if (!Directory.Exists(_filePath)) 
        {
            Directory.CreateDirectory(_filePath);
        }
    }
    public override async Task<Empty> UploadFile(IAsyncStreamReader<ByteContent> requestStream, ServerCallContext context) 
    {
        FileStream fileStream = null;
        decimal chunkSize = 0;
        var init  = true;
        await foreach (var bytecontent in requestStream.ReadAllAsync()) 
        {
            if (init)
            {
                fileStream = new FileStream($"{_filePath}/{bytecontent.ImageRequest.FileExtention}", FileMode.CreateNew, FileAccess.Write);
            }
            var buffer = bytecontent.Buffer.ToByteArray();
            await fileStream.WriteAsync(buffer, 0, buffer.Length);
            chunkSize += bytecontent.ReadedByte;
            Console.WriteLine($"{Math.Round(chunkSize * 100/bytecontent.FileSize)} %");
            init = false;
        }
        await fileStream.DisposeAsync();
        fileStream.Close();
        return new Empty();
    }
}
