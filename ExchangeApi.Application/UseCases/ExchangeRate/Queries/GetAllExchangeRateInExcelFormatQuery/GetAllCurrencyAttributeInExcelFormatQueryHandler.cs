using ExchangeApi.Application.Contracts;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace ExchangeApi.Application.UseCases.ExchangeRate.Queries.GetAllExchangeRateInExcelFormatQuery;

public class GetAllCurrencyAttributeInExcelFormatQueryHandler(IExcelFileProcessor excelFileProcessor) 
    : IRequestHandler<GetAllExchangeRateInExcelFormatQuery,FileResult>
{
    public async Task<FileResult> Handle(GetAllExchangeRateInExcelFormatQuery request, CancellationToken cancellationToken)
    {
        var stream = await excelFileProcessor
            .ExportToExcelAsync<Domain.Entities.ExchangeRate>
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