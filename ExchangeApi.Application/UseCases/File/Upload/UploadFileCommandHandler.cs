using AutoMapper;
using ExchangeApi.Application.Contracts;
using ExchangeApi.Domain.Wrappers;
using MediatR;

namespace ExchangeApi.Application.UseCases.File.Upload;
public class UploadFileCommandHandler : IRequestHandler<UploadFileCommand, Response<bool>>
{
    private readonly IMapper _mapper;
    private readonly IFileService _fileService;
    public UploadFileCommandHandler(IMapper mapper, IFileService fileService)
    {
        _mapper = mapper;
        _fileService = fileService;
    }

    public async Task<Response<bool>> Handle(UploadFileCommand request, CancellationToken ct)
    {
        if (request.File == null || request.File.Length == 0)
            return new Response<bool>("No file uploaded.");

        const int MaxFileSize = 5 * 1024 * 1024; // 5MB in bytes
        if (request.File.Length > MaxFileSize)
            return new Response<bool>("The File has to be 5mb");

        var allowedExtensions = new[] { ".jpg", ".jpeg", ".png", ".heic", ".pdf" };
        var fileExtension = Path.GetExtension(request.File.FileName).ToLower();
        if (!allowedExtensions.Contains(fileExtension))
            return new Response<bool>("Please send file with thes format jpg/jpeg/png/heic/pdf");

        var allowedContentTypes = new[] { "image/jpeg", "image/png", "image/heif", "application/pdf" };
        if (!allowedContentTypes.Contains(request.File.ContentType))
            return new Response<bool>("the type is not in correct format");

        var fileEntity = _mapper.Map<ExchangeApi.Domain.Entities.File>(request);

        var FileStatus = await _fileService.UploadFileAsync(fileEntity, ct);

        return FileStatus.Succeeded ? new Response<bool>(FileStatus.Data) : new Response<bool>(FileStatus.Message);
    }

}
