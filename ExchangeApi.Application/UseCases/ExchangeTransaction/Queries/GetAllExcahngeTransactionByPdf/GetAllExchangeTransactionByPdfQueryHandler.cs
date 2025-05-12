using ExchangeApi.Application.Contracts;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace ExchangeApi.Application.UseCases.ExchangeTransaction.Queries.GetAllExcahngeTransactionByPdf;

public class GetAllExchangeTransactionByPdfQueryHandler(IPdfService service) 
    : IRequestHandler<GetAllExchangeTransactionByPdfQuery, FileContentResult>
{
    
    public Task<FileContentResult> Handle(GetAllExchangeTransactionByPdfQuery request
        , CancellationToken cancellationToken)
    {
        var pdfBytes = service
            .GeneratePdf<Domain.Entities.ExchangeTransaction>
                (request.Title);

        var fileResult = new
            FileContentResult
            (pdfBytes, "application/pdf")
        {
            FileDownloadName 
            = "CurrencyReport.pdf"
        };

        return Task
        .FromResult(fileResult);
    }
}