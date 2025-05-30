using ExchangeApi.Application.Contracts;
using ExchangeApi.Application.Dtos;
using ExchangeApi.Domain.Wrappers;
using FluentValidation;
using MediatR;

namespace ExchangeApi.Application.UseCases.Currency.Commands.UploadExcelFile;

public class UploadCurrencyByExcelFileCommandHandler(IExcelFileProcessor excelFileProcessor,
    IValidator<UploadCurrencyByExcelFileCommand> uploadCurrencyByExcelFileCommandValidator) 
    : IRequestHandler<UploadCurrencyByExcelFileCommand,Response<ExcelFileResponseDto>>
{
    public async Task<Response<ExcelFileResponseDto>> Handle(UploadCurrencyByExcelFileCommand request
        , CancellationToken ct)
    {
        await uploadCurrencyByExcelFileCommandValidator
        .ValidateAndThrowAsync(request,ct);
        
        if (request.ImportFile is null || request.ImportFile.Length == 0)
            return new Response<ExcelFileResponseDto>("File is empty");

        var processed = await excelFileProcessor
            .ImportDataByExcel<Domain.Entities.Currency>(request.ImportFile, request.HasHeader, ct);

        return processed.Succeeded == true ?
            new Response<ExcelFileResponseDto>(processed.Data) 
            : new Response<ExcelFileResponseDto>(processed.Message);
    }
}