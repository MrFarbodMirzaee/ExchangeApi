using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace ExchangeApi.Application.UseCases.CurrencyAttribute.Query.GetAllCurrencyAttributeByPdf;

public class GetAllCurrencyAttributeByPdfQuery : IRequest<FileContentResult>
{
    [FromQuery] public string Title { get; set; }
}