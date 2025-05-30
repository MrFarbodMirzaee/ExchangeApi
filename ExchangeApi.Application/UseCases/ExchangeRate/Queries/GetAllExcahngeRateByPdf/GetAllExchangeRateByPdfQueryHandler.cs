using ExchangeApi.Application.Contracts;
using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace ExchangeApi.Application.UseCases.ExchangeRate.Queries.GetAllExcahngeRateByPdf;

public class GetAllExchangeRateByPdfQueryHandler(IPdfService service,
    IValidator<GetAllExchangeRateByPdfQuery> getAllExchangeRateByPdfQueryValidator) 
    : IRequestHandler<GetAllExchangeRateByPdfQuery, FileContentResult>
{
    
    public async Task<FileContentResult> Handle(GetAllExchangeRateByPdfQuery request
        , CancellationToken ct)
    {
        await getAllExchangeRateByPdfQueryValidator.ValidateAndThrowAsync(request, ct);
        
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

        return await Task
        .FromResult(fileResult);
    }
}