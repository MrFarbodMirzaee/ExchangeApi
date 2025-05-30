using ExchangeApi.Application.Contracts;
using ExchangeApi.Application.Dtos;
using ExchangeApi.Domain.Wrappers;
using FluentValidation;
using MediatR;

namespace ExchangeApi.Application.UseCases.CurrencyAttribute.Commands.UploadCurrencyAttributeByExcel;

public class UploadCurrencyAttributeByExcleCommandHandler(IExcelFileProcessor excelFileProcessor,
    IValidator<UploadCurrencyAttributeByExcelCommand> uploadCurrencyAttributeByExcelCommandValidator) 
    : IRequestHandler<UploadCurrencyAttributeByExcelCommand,Response<ExcelFileResponseDto>>
{
    public async Task<Response<ExcelFileResponseDto>> Handle(UploadCurrencyAttributeByExcelCommand request
        , CancellationToken ct)
    {
        await uploadCurrencyAttributeByExcelCommandValidator
        .ValidateAndThrowAsync(request,ct);
        
        if (request.ImportFile is null || request.ImportFile.Length == 0)
            return new 
                Response<ExcelFileResponseDto>
                ("File is empty");

        var processed = await excelFileProcessor
            .ImportDataByExcel<Domain.Entities.CurrencyAttribute>
                (request.ImportFile, request.HasHeader, ct);

        return processed.Succeeded == true ? 
            new Response<ExcelFileResponseDto>(processed.Data) :
            new Response<ExcelFileResponseDto>(processed.Message);
    }
}