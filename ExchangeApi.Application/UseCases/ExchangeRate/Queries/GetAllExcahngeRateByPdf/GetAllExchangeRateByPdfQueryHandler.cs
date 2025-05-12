using ExchangeApi.Application.Contracts;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace ExchangeApi.Application.UseCases.ExchangeRate.Queries.GetAllExcahngeRateByPdf;

public class GetAllExchangeRateByPdfQueryHandler(IPdfService service) 
    : IRequestHandler<GetAllExchangeRateByPdfQuery, FileContentResult>
{
    
    public Task<FileContentResult> Handle(GetAllExchangeRateByPdfQuery request
        , CancellationToken cancellationToken)
    {
        var pdfBytes = service
            .GeneratePdf<Domain.Entities.ExchangeRate>
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