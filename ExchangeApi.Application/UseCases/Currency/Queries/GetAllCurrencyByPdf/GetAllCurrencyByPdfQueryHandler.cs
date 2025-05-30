using ExchangeApi.Application.Contracts;
using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace ExchangeApi.Application.UseCases.Currency.Queries.GetAllCurrencyByPdf;

public class GetAllCurrencyByPdfQueryHandler(IPdfService service,
    IValidator<GetAllCurrencyByPdfQuery> getAllCurrencyByPdfQueryValidator) 
    : IRequestHandler<GetAllCurrencyByPdfQuery, FileContentResult>
{
    
    public async Task<FileContentResult> Handle(GetAllCurrencyByPdfQuery request
        , CancellationToken ct)
    {
        await getAllCurrencyByPdfQueryValidator
        .ValidateAndThrowAsync(request,ct);
        
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

        return await Task
        .FromResult(fileResult);
    }
}