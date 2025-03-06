using Exchange.gRPCServer.Context;
using Exchange.gRPCServer.Protos;
using Grpc.Core;
using Microsoft.EntityFrameworkCore;

namespace Exchange.gRPCServer.Services;

public class DownloadFileService(AppDbContext appDbContext) : DownloadFileStreaming.DownloadFileStreamingBase
{
    public override async Task DownloadFileById(FileRequestById request,
        IServerStreamWriter<FileContent> responseStream, ServerCallContext context)
    {
        var fileRecord = await appDbContext.File.FirstOrDefaultAsync(f => f.Id == request.Id);

        if (fileRecord == null)
        {
            throw new RpcException(new Status(StatusCode.NotFound, "File not found"));
        }

        var fileBytes = fileRecord.Content;
        var chunkSize = 1024 * 64;
        var fileName = fileRecord.FileName;

        await responseStream.WriteAsync(new FileContent
        {
            Content = Google.Protobuf.ByteString.Empty,
            FileName = fileName,
            ChunkSize = fileBytes.Length
        });

        for (int i = 0; i < fileBytes.Length; i += chunkSize)
        {
            var chunk = fileBytes.Skip(i).Take(chunkSize).ToArray();

            await responseStream.WriteAsync(new FileContent
            {
                Content = Google.Protobuf.ByteString.CopyFrom(chunk),
                ChunkSize = chunk.Length
            });

            Console.WriteLine($"Sent {Math.Min(i + chunkSize, fileBytes.Length)} of {fileBytes.Length} bytes...");
        }
    }
}