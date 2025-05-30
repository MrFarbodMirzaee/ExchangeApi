using ExchangeApi.Application.Dtos;
using ExchangeApi.Domain.Wrappers;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ExchangeApi.Application.UseCases.Currency.Commands.UploadExcelFile;

public class UploadCurrencyByExcelFileCommand : IRequest<Response<ExcelFileResponseDto>>
{
    [FromForm]
    public IFormFile ImportFile { get; set; }
    [FromForm]
    public bool HasHeader { get; set; }
}