using ExchangeApi.Application.Contracts;
using ExchangeApi.Application.Dtos;
using ExchangeApi.Domain.Wrappers;
using MediatR;

namespace ExchangeApi.Application.UseCases.Currency.Commands.UploadExcleFile;

public class UploadCurrencyByExcleFileCommandHandler(IExcelFileProcessor excelFileProcessor) 
    : IRequestHandler<UploadCurrencyByExcleFileCommand,Response<ExcelFileResponseDto>>
{
    public async Task<Response<ExcelFileResponseDto>> Handle(UploadCurrencyByExcleFileCommand command
        , CancellationToken cancellationToken)
    {
        if (command.ImportFile is null || command.ImportFile.Length == 0)
            return new Response<ExcelFileResponseDto>("File is empty");

        var processed = await excelFileProcessor
            .ImportDataByExcel<Domain.Entities.Currency>(command.ImportFile, command.HasHeader, cancellationToken);

        return processed.Succeeded == true ?
            new Response<ExcelFileResponseDto>(processed.Data) 
            : new Response<ExcelFileResponseDto>(processed.Message);
    }
}