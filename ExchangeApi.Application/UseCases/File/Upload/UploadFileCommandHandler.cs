using AutoMapper;
using ExchangeApi.Application.Contracts;
using ExchangeApi.Domain.Wrappers;
using FluentValidation;
using MediatR;

namespace ExchangeApi.Application.UseCases.File.Upload;

public class UploadFileCommandHandler(IMapper mapper, IFileService fileService,
    IValidator<UploadFileCommand> uploadFileCommandValidator)
    : IRequestHandler<UploadFileCommand, Response<bool>>
{
    public async Task<Response<bool>> Handle(UploadFileCommand request, CancellationToken ct)
    {
        await uploadFileCommandValidator
        .ValidateAndThrowAsync(request, ct);
        
        if (request.File == null || request.File.Length == 0)
            return new Response<bool>("No file uploaded.");

        const int maxFileSize = 5 * 1024 * 1024; 
        
        if (request.File.Length > maxFileSize)
            return new Response<bool>("The File has to be 5mb");

        var allowedExtensions = new[] { ".jpg", ".jpeg", ".png", ".heic", ".pdf" };
        
        var fileExtension = Path.GetExtension(request.File.FileName).ToLower();
        
        if (!allowedExtensions.Contains(fileExtension))
            return new Response<bool>("Please send file with thes format jpg/jpeg/png/heic/pdf");

        var allowedContentTypes = new[] { "image/jpeg", "image/png", "image/heif", "application/pdf" };
        
        if (!allowedContentTypes.Contains(request.File.ContentType))
            return new Response<bool>("the type is not in correct format");

        var fileEntity = mapper.Map<ExchangeApi.Domain.Entities.File>(request);

        var fileStatus = await fileService.UploadFileAsync(fileEntity, ct);

        return fileStatus.Succeeded 
            ? new Response<bool>(fileStatus.Data)
            : new Response<bool>(fileStatus.Message);
    }
}