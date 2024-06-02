using ExchangeApi.Domain.Wrappers;
using MediatR;
using Microsoft.AspNetCore.Http;

namespace ExchangeApi.Application.UseCases.Currency.Commands;

public class UploadPictureCommand : IRequest<Response<int>>
{
    public IFormFile File { get; set; }
}
