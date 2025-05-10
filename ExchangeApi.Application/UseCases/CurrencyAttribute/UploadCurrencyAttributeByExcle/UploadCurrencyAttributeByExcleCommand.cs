using ExchangeApi.Application.Dtos;
using ExchangeApi.Domain.Wrappers;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ExchangeApi.Application.UseCases.CurrencyAttribute.UploadCurrencyAttributeByExcle;

public class UploadCurrencyAttributeByExcleCommand : IRequest<Response<ExcelFileResponseDto>>
{
    [FromForm]
    public IFormFile ImportFile { get; set; }
    [FromForm]
    public bool HasHeader { get; set; }
}