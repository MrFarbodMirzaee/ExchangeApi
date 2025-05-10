using ExchangeApi.Application.Contracts;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace ExchangeApi.Application.UseCases.User.Queries.GetAllUserInExcelFormatQuery;

public class GetAllUserInExcelFormatQueryHandler(IExcelFileProcessor excelFileProcessor) 
    : IRequestHandler<GetAllUserInExcelFormatQuery,FileResult>
{
    public async Task<FileResult> Handle(GetAllUserInExcelFormatQuery request, CancellationToken cancellationToken)
    {
        var stream = await excelFileProcessor
            .ExportToExcelAsync<Domain.Entities.User>
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