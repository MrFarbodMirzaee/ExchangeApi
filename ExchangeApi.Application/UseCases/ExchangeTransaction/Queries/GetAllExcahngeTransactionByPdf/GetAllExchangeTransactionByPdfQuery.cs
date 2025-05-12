using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace ExchangeApi.Application.UseCases.ExchangeTransaction.Queries.GetAllExcahngeTransactionByPdf;

public class GetAllExchangeTransactionByPdfQuery : IRequest<FileContentResult>
{
    [FromQuery] public string Title { get; set; }
}