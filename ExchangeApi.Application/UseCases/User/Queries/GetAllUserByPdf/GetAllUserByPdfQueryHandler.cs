using ExchangeApi.Application.Contracts;
using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace ExchangeApi.Application.UseCases.User.Queries.GetAllUserByPdf;

public class GetAllUserByPdfQueryHandler(IPdfService service,
    IValidator<GetAllUserByPdfQuery> getAllUserByPdfQueryValidator) 
    : IRequestHandler<GetAllUserByPdfQuery, FileContentResult>
{
    
    public async Task<FileContentResult> Handle(GetAllUserByPdfQuery request
        , CancellationToken ct)
    {
        await getAllUserByPdfQueryValidator
            .ValidateAndThrowAsync(request,ct);
        
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

        return await Task
        .FromResult(fileResult);
    }
}