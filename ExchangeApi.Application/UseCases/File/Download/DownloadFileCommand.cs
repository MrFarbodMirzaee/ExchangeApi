using ExchangeApi.Application.Dtos;
using ExchangeApi.Domain.Wrappers;
using MediatR;

namespace ExchangeApi.Application.UseCases.File.Download;

public class DownloadFileCommand : IRequest<Response<DownloadFileDto>>
{
    public int FileId { get; set; }

    public DownloadFileCommand(int fileId)
    {
        FileId = fileId;
    }
}
