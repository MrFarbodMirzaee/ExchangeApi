using ExchangeApi.Application.Dtos;
using ExchangeApi.Domain.Wrappers;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ExchangeApi.Application.UseCases.Currency.Commands.UploadExcleFile;

public class UploadCurrencyByExcleFileCommand : IRequest<Response<ExcelFileResponseDto>>
{
    [FromForm]
    public IFormFile ImportFile { get; set; }
    [FromForm]
    public bool HasHeader { get; set; }
}