using ExchangeApi.Domain.Wrappers;
using MediatR;
using Microsoft.AspNetCore.Http;

namespace ExchangeApi.Application.UseCases.File.Upload;

public class UploadFileCommand : IRequest<Response<bool>>
{
    public IFormFile File { get; set; }
}