using ExchangeApi.Application.Contracts;
using ExchangeApi.Application.Dtos;
using ExchangeApi.Domain.Wrappers;
using MediatR;

namespace ExchangeApi.Application.UseCases.CurrencyAttribute.UploadCurrencyAttributeByExcle;

public class UploadCurrencyAttributeByExcleCommandHandler(IExcelFileProcessor excelFileProcessor) 
    : IRequestHandler<UploadCurrencyAttributeByExcleCommand,Response<ExcelFileResponseDto>>
{
    public async Task<Response<ExcelFileResponseDto>> Handle(UploadCurrencyAttributeByExcleCommand request
        , CancellationToken cancellationToken)
    {
        if (request.ImportFile is null || request.ImportFile.Length == 0)
            return new 
                Response<ExcelFileResponseDto>
                        ("File is empty");

        var processed = await excelFileProcessor
            .ImportDataByExcel<Domain.Entities.CurrencyAttribute>
                (request.ImportFile, request.HasHeader, cancellationToken);

        return processed.Succeeded == true ? 
            new Response<ExcelFileResponseDto>(processed.Data) :
            new Response<ExcelFileResponseDto>(processed.Message);
    }
}