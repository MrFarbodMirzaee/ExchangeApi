using ExchangeApi.Application.Contracts;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace ExchangeApi.Application.UseCases.Currency.Queries.GetAllCurrencyByPdf;

public class GetAllCurrencyByPdfQueryHandler(IPdfService service) 
    : IRequestHandler<GetAllCurrencyByPdfQuery, FileContentResult>
{
    
    public Task<FileContentResult> Handle(GetAllCurrencyByPdfQuery request
        , CancellationToken cancellationToken)
    {
        var pdfBytes = service
            .GeneratePdf<Domain.Entities.Currency>
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