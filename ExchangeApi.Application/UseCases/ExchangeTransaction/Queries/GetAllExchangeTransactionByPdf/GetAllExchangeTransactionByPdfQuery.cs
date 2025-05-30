using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace ExchangeApi.Application.UseCases.ExchangeTransaction.Queries.GetAllExchangeTransactionByPdf;

public class GetAllExchangeTransactionByPdfQuery : IRequest<FileContentResult>
{
    [FromQuery] public string Title { get; set; }
}