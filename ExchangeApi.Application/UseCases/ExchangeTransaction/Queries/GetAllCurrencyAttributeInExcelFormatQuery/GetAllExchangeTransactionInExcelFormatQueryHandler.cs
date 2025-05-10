using ExchangeApi.Application.Contracts;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace ExchangeApi.Application.UseCases.ExchangeTransaction.Queries.GetAllCurrencyAttributeInExcelFormatQuery;

public class GetAllExchangeTransactionInExcelFormatQueryHandler(IExcelFileProcessor excelFileProcessor) 
    : IRequestHandler<GetAllExchangeTransactionInExcelFormatQuery,FileResult>
{
    public async Task<FileResult> Handle(GetAllExchangeTransactionInExcelFormatQuery request, CancellationToken cancellationToken)
    {
        var stream = await excelFileProcessor
            .ExportToExcelAsync<Domain.Entities.ExchangeTransaction>
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