using ExchangeApi.Application.Dtos;
using ExchangeApi.Domain.Wrappers;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ExchangeApi.Application.UseCases.CurrencyAttribute.Commands.UploadCurrencyAttributeByExcel;

public class UploadCurrencyAttributeByExcelCommand : IRequest<Response<ExcelFileResponseDto>>
{
    [FromForm]
    public IFormFile ImportFile { get; set; }
    [FromForm]
    public bool HasHeader { get; set; }
}