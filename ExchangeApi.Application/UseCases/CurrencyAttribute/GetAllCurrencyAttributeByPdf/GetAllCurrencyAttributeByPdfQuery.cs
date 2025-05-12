using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace ExchangeApi.Application.UseCases.CurrencyAttribute.GetAllCurrencyAttributeByPdf;

public class GetAllCurrencyAttributeByPdfQuery : IRequest<FileContentResult>
{
    [FromQuery] public string Title { get; set; }
}