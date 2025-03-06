using ExchangeApi.Application.Contracts;
using ExchangeApi.Application.Dtos;
using ExchangeApi.Domain.Wrappers;
using MediatR;

namespace ExchangeApi.Application.UseCases.File.Download;

public class DownloadFileCommandHandler(IFileService fileService)
    : IRequestHandler<DownloadFileCommand, Response<DownloadFileDto>>
{
    public async Task<Response<DownloadFileDto>> Handle(DownloadFileCommand request,
        CancellationToken cancellationToken)
    {
        var downloaded = await fileService.DownloadFileAsync(request.FileId, cancellationToken);

        return new Response<DownloadFileDto>(downloaded);
    }
}