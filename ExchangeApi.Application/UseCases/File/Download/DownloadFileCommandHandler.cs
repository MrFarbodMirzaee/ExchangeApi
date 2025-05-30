using ExchangeApi.Application.Contracts;
using ExchangeApi.Application.Dtos;
using ExchangeApi.Domain.Wrappers;
using FluentValidation;
using MediatR;

namespace ExchangeApi.Application.UseCases.File.Download;

public class DownloadFileCommandHandler(IFileService fileService,
    IValidator<DownloadFileCommand> downloadFileCommandValidator)
    : IRequestHandler<DownloadFileCommand, Response<DownloadFileDto>>
{
    public async Task<Response<DownloadFileDto>> Handle(DownloadFileCommand request,
        CancellationToken ct)
    {
        await downloadFileCommandValidator
        .ValidateAndThrowAsync(request, ct); 
        
        var downloaded = await 
        fileService
        .DownloadFileAsync(request.FileId, ct);

        return new
            Response<DownloadFileDto>
            (downloaded);
    }
}