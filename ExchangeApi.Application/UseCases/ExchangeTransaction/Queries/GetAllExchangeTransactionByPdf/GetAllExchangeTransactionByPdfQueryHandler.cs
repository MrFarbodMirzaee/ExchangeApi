using ExchangeApi.Application.Contracts;
using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace ExchangeApi.Application.UseCases.ExchangeTransaction.Queries.GetAllExchangeTransactionByPdf;

public class GetAllExchangeTransactionByPdfQueryHandler(IPdfService service,
    IValidator<GetAllExchangeTransactionByPdfQuery> getAllExchangeTransactionByPdfQueryValidator) 
    : IRequestHandler<GetAllExchangeTransactionByPdfQuery, FileContentResult>
{
    
    public async Task<FileContentResult> Handle(GetAllExchangeTransactionByPdfQuery request
        , CancellationToken ct)
    {
        await getAllExchangeTransactionByPdfQueryValidator
        .ValidateAndThrowAsync(request, ct);
        
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

        return await Task
        .FromResult(fileResult);
    }
}