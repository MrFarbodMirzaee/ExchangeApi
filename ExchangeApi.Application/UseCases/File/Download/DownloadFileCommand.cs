using ExchangeApi.Application.Dtos;
using ExchangeApi.Domain.Wrappers;
using MediatR;

namespace ExchangeApi.Application.UseCases.File.Download;

public class DownloadFileCommand(Guid fileId) : IRequest<Response<DownloadFileDto>>
{
    public Guid FileId { get; set; } = fileId;
}