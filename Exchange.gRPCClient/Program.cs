using System.Reflection;
using Grpc.Net.Client;
using System.Diagnostics;
using Exchange.gRPCServer.Protos;
using Google.Protobuf;

namespace Exchange.gRPCClient;

internal class Program
{
    static async Task Main(string[] args)
    {   
        var sp = new Stopwatch();
        string address = "https://localhost:7219";
        var channel = GrpcChannel.ForAddress(address);

        var client = new CurrencyFileStreaming.CurrencyFileStreamingClient(channel);

        var contentRootPath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
        string file = Path.Combine(contentRootPath, "Files");
        var fileInfo = new FileInfo(file);

        decimal chunkSize = 0;
        var buffer  =new byte[1024 * 2];
        using var call = client.UploadFile();
        using var fileStrem = new FileStream(file, FileMode.Open);

        var content = new ByteContent 
        {
            FileSize = fileStrem.Length,
            ReadedByte = 0,
            ImageRequest = new ImageRequest {FileName = Path.GetFileNameWithoutExtension(fileInfo.Name), FileExtention = Path.GetExtension(fileInfo.Name).TrimStart('.') }
        };
        while ((content.ReadedByte = fileStrem.Read(buffer, 0, buffer.Length)) > 0) 
        {
            content.Buffer = ByteString.CopyFrom(buffer);
            await call.RequestStream.WriteAsync(content);
            chunkSize += buffer.Length;
            Console.WriteLine($"{Math.Round(chunkSize * 100 / fileStrem.Length)} %");
            await Task.Delay(100);
        }
        await call.RequestStream.CompleteAsync();
        Console.ReadKey();
    }
}
