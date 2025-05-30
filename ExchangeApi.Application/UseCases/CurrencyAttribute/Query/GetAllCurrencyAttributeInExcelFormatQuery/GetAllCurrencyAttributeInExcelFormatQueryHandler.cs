using ExchangeApi.Application.Contracts;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace ExchangeApi.Application.UseCases.CurrencyAttribute.Query.GetAllCurrencyAttributeInExcelFormatQuery;

public class GetAllCurrencyAttributeInExcelFormatQueryHandler(IExcelFileProcessor excelFileProcessor) 
    : IRequestHandler<GetAllCurrencyAttributeInExcelFormatQuery ,FileResult>
{
    public async Task<FileResult> Handle(GetAllCurrencyAttributeInExcelFormatQuery request, CancellationToken cancellationToken)
    {
        var stream = await excelFileProcessor
            .ExportToExcelAsync<Domain.Entities.CurrencyAttribute>
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