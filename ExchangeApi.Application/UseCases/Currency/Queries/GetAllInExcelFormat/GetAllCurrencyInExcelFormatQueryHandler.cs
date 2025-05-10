using ExchangeApi.Application.Contracts;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace ExchangeApi.Application.UseCases.Currency.Queries.GetAllInExcelFormat;

public class GetAllCurrencyInExcelFormatQueryHandler(IExcelFileProcessor excelFileProcessor) 
    : IRequestHandler<GetAllCurrencyInExcelFormatQuery ,FileResult>
{
    public async Task<FileResult> Handle(GetAllCurrencyInExcelFormatQuery request, CancellationToken cancellationToken)
    {
        var stream = await excelFileProcessor
            .ExportToExcelAsync<Domain.Entities.Currency>
                (cancellationToken);
        
        var fileResult = new 
            FileStreamResult
            (stream, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet")
        {
            FileDownloadName = "Currencies.xlsx"
        };
        
        return fileResult;
    }
}