using Exchange.gRPCServer.Context;
using Exchange.gRPCServer.Protos;
using Grpc.Core;

namespace Exchange.gRPCServer.Services;
public class GrpcCurrencyImageFileStreamingService : CurrencyFileStreaming.CurrencyFileStreamingBase
{
    private readonly AppDbContext _appDbContext;

    public GrpcCurrencyImageFileStreamingService(AppDbContext appDbContext) => _appDbContext = appDbContext;

    public override async Task<UploadStatus> UploadFile(IAsyncStreamReader<FileChunk> requestStream, ServerCallContext context)
    {
        try
        {
            var buffer = new List<byte>();
            string fileName = string.Empty;
            long fileSize = 0;

            await foreach (var chunk in requestStream.ReadAllAsync())
            {
                if (string.IsNullOrEmpty(fileName))
                {
                    fileName = chunk.FileName;
                    fileSize = chunk.FileSize;
                }

                buffer.AddRange(chunk.Content.ToByteArray());
            }

            var fileRecord = new Exchange.gRPCServer.Entities.File
            {
                FileName = fileName,
                Content = buffer.ToArray(),
                Size = fileSize
            };

            await _appDbContext.File.AddAsync(fileRecord);
            await _appDbContext.SaveChangesAsync();

            return new UploadStatus { Success = true, Message = "File uploaded successfully." };
        }
        catch (Exception ex)
        {
            return new UploadStatus { Success = false, Message = $"Error: {ex.Message}" };
        }
    }
}
