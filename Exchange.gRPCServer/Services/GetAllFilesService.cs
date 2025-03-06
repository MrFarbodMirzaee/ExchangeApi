using Exchange.gRPCServer.Context;
using Exchange.gRPCServer.Protos;
using Grpc.Core;
using Microsoft.EntityFrameworkCore;

namespace Exchange.gRPCServer.Services;

public class GetAllFilesService(AppDbContext dbContext) : FileService.FileServiceBase
{
    public override async Task GetAllFiles(Empty request, IServerStreamWriter<FileMetadata> responseStream,
        ServerCallContext context)
    {
        var files = await dbContext.File.ToListAsync();

        if (files.Count == 0)
        {
            throw new RpcException(new Status(StatusCode.NotFound, "No files found in the database."));
        }

        foreach (var file in files)
        {
            var fileMetadata = new FileMetadata
            {
                FileName = Path.GetFileNameWithoutExtension(file.FileName),
                FileSize = file.Size,
                FileExtension = Path.GetExtension(file.FileName),
            };

            await responseStream.WriteAsync(fileMetadata);

            Console.WriteLine($"Sending file: {file.FileName}, Size: {file.Size} bytes");
        }
    }
}