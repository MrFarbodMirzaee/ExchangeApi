using ExchangeApi.Application.Dtos;
using ExchangeApi.Domain.Wrappers;
using Microsoft.AspNetCore.Http;

namespace ExchangeApi.Application.Contracts;

public interface IExcelFileProcessor
{
    Task<Response<ExcelFileResponseDto>> ImportDataByExcel<TEntity>(IFormFile file, bool hasHeader, CancellationToken cancellationToken)  where TEntity : class, new();
    Task<MemoryStream> ExportToExcelAsync<TEntity>(CancellationToken cancellationToken) where TEntity : class, new();
}