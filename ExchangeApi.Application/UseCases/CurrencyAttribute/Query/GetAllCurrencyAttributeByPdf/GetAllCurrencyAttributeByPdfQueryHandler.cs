using ExchangeApi.Application.Contracts;
using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace ExchangeApi.Application.UseCases.CurrencyAttribute.Query.GetAllCurrencyAttributeByPdf;

public class GetAllCurrencyAttributeByPdfQueryHandler(IPdfService service,
    IValidator<GetAllCurrencyAttributeByPdfQuery> getAllCurrencyAttributeByPdfQueryValidator) 
    : IRequestHandler<GetAllCurrencyAttributeByPdfQuery, FileContentResult>
{
    
    public async Task<FileContentResult> Handle(GetAllCurrencyAttributeByPdfQuery request
        , CancellationToken ct)
    {
        await getAllCurrencyAttributeByPdfQueryValidator
        .ValidateAndThrowAsync(request,ct);
        
        var pdfBytes = service
            .GeneratePdf<Domain.Entities.CurrencyAttribute>
            (request.Title);

        var fileResult = new
            FileContentResult(pdfBytes, "application/pdf")
        {
            FileDownloadName 
            = "CurrencyReport.pdf"
        };

        return await Task
        .FromResult(fileResult);
    }
}