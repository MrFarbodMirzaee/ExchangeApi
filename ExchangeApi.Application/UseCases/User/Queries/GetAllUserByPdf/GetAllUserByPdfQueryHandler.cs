using ExchangeApi.Application.Contracts;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace ExchangeApi.Application.UseCases.User.Queries.GetAllUserByPdf;

public class GetAllUserByPdfQueryHandler(IPdfService service) 
    : IRequestHandler<GetAllUserByPdfQuery, FileContentResult>
{
    
    public Task<FileContentResult> Handle(GetAllUserByPdfQuery request
        , CancellationToken cancellationToken)
    {
        var pdfBytes = service
            .GeneratePdf<Domain.Entities.User>
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