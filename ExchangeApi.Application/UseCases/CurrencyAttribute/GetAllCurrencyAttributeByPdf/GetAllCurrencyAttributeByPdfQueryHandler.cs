using ExchangeApi.Application.Contracts;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace ExchangeApi.Application.UseCases.CurrencyAttribute.GetAllCurrencyAttributeByPdf;

public class GetAllCurrencyAttributeByPdfQueryHandler(IPdfService service) 
    : IRequestHandler<GetAllCurrencyAttributeByPdfQuery, FileContentResult>
{
    
    public Task<FileContentResult> Handle(GetAllCurrencyAttributeByPdfQuery request
        , CancellationToken cancellationToken)
    {
        var pdfBytes = service
            .GeneratePdf<Domain.Entities.CurrencyAttribute>
                (request.Title);

        var fileResult = new
            FileContentResult(pdfBytes, "application/pdf")
        {
            FileDownloadName 
            = "CurrencyReport.pdf"
        };

        return Task
        .FromResult(fileResult);
    }
}