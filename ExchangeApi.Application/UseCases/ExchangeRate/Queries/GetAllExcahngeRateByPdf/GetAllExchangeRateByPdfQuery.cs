using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace ExchangeApi.Application.UseCases.ExchangeRate.Queries.GetAllExcahngeRateByPdf;

public class GetAllExchangeRateByPdfQuery : IRequest<FileContentResult>
{
    [FromQuery] public string Title { get; set; }
}