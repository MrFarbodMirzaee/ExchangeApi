using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace ExchangeApi.Application.UseCases.Currency.Queries.GetAllCurrencyByPdf;

public class GetAllCurrencyByPdfQuery : IRequest<FileContentResult>
{
    [FromQuery] public string Title { get; set; }
}