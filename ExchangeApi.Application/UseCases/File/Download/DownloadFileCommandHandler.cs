using ExchangeApi.Application.Contracts;
using ExchangeApi.Application.Dtos;
using ExchangeApi.Domain.Wrappers;
using MediatR;

namespace ExchangeApi.Application.UseCases.File.Download;
public class DownloadFileCommandHandler : IRequestHandler<DownloadFileCommand, Response<DownloadFileDto>>
{
    private readonly IFileService _fileService;

    public DownloadFileCommandHandler(IFileService fileService) => _fileService = fileService;
    public async Task<Response<DownloadFileDto>> Handle(DownloadFileCommand request, CancellationToken cancellationToken)
    {
        var downloaded = await _fileService.DownloadFileAsync(request.FileId, cancellationToken);

        return downloaded.FileData.Count() > 0 ? new Response<DownloadFileDto>(downloaded) : downloaded.;
    }
}
