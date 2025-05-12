using ClosedXML.Excel;
using ExchangeApi.Application.Attributes;
using ExchangeApi.Application.Contracts;
using ExchangeApi.Application.Dtos;
using ExchangeApi.Infrastructure.Persistence.Contexts;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;

namespace ExchangeApi.Infrastructure.Persistence.Services;

[ScopedService]
public class ExcelFileProcessor(AppDbContext context) : IExcelFileProcessor
{
    public async Task<Domain.Wrappers.Response<ExcelFileResponseDto>> ImportDataByExcel<TEntity>(IFormFile file, bool hasHeader,
        CancellationToken cancellationToken)
        where TEntity : class, new()
    {
        using var memoryStream = 
                new MemoryStream();
        await file
                .CopyToAsync(memoryStream, cancellationToken);
        memoryStream.Position = 0;

        using var workbook = 
                new XLWorkbook(memoryStream);
        var worksheet = workbook
                .Worksheets
                .First();

        var rows = 
                new List<List<string>>();
        var columnCount = 
            worksheet
                .ColumnsUsed()
                .Count();

        var headers = hasHeader
            ? worksheet.Row(1)
                .Cells(1, columnCount)
                .Select(c => 
                 c.GetString()
                .Trim())
                .ToList()
            : throw new 
                InvalidOperationException("Header is required for dynamic mapping");

        var entityProps = typeof(TEntity)
                .GetProperties()
                .Select(p => p.Name)
                .ToHashSet(StringComparer.OrdinalIgnoreCase);

        var invalidHeaders = headers
            .Where(h => !entityProps.Contains(h))
                .ToList();

        if (invalidHeaders.Any())
        {
            var invalids = string
                    .Join(", ", invalidHeaders);
            return new
                 Domain.Wrappers.Response<ExcelFileResponseDto>
                        ($"Invalid header(s) detected: {invalids}");
        }

        var headerToIndex = 
            headers
                .Select((header, index)
                        => new { header, index = index + 1 })
            .ToDictionary(x 
                    => x.header, x => x.index);

        var entities = 
            new List<TEntity>();

        foreach (var row in worksheet.RowsUsed()
                     .Skip(1))
        {
            var entity =
                new TEntity();

            foreach (var prop in 
                          typeof(TEntity)
                         .GetProperties())
            {
                if (!headerToIndex
                    .TryGetValue(prop.Name, out int colIndex))
                    continue;

                var cellValue = 
                         row
                        .Cell(colIndex)
                        .GetString();
                
                object? value = null;

                if (prop.PropertyType == typeof(Guid))
                {
                    if (Guid
                        .TryParse(cellValue, out var guid))
                        value = guid;
                }
                else if (prop.PropertyType == typeof(decimal))
                {
                    if (decimal
                        .TryParse(cellValue, out var dec))
                        value = dec;
                }
                else if (prop.PropertyType == typeof(int))
                {
                    if (int
                        .TryParse(cellValue, out var i))
                        value = i;
                }
                else if (prop
                        .PropertyType == typeof(DateTime))
                {
                    if (DateTime
                        .TryParse(cellValue, out var dt))
                        value = dt;
                }
                else if (prop
                        .PropertyType == typeof(string))
                {
                    value = cellValue;
                }

                if (value != null)
                    prop.SetValue(entity, value);
            }

            var idProp = typeof(TEntity)
                .GetProperty("Id");
            if (idProp != null && 
                idProp.PropertyType == typeof(Guid))
                idProp
                    .SetValue(entity, 
                    Guid.NewGuid());

            entities
            .Add(entity);

            rows.Add(headers.Select
                (h => row.Cell
                    (headerToIndex[h])
                    .GetString())
                    .ToList());
        }

        context
            .Set<TEntity>()
            .AddRange(entities);
        
        await context
            .SaveChangesAsync(cancellationToken);

        var response = new ExcelFileResponseDto(
            RowCount: rows.Count,
            ColumnCount: columnCount,
            Data: rows,
            Headers: headers,
            SheetName: worksheet.Name
        );

        return new Domain.Wrappers.Response<ExcelFileResponseDto>(response);
    }

    public async Task<MemoryStream> ExportToExcelAsync<TEntity>(CancellationToken cancellationToken) where TEntity : class, new()
    {
        var data = await context.Set<TEntity>().ToListAsync(cancellationToken);
        var props = typeof(TEntity).GetProperties();

        using var workbook = new XLWorkbook();
        var worksheet = workbook.Worksheets.Add(typeof(TEntity).Name);

        for (int i = 0; i < props.Length; i++)
        {
            worksheet.Cell(1, i + 1).Value = props[i].Name;
        }

        for (int row = 0; row < data.Count; row++)
        {
            var item = data[row];
            for (int col = 0; col < props.Length; col++)
            {
                var rawValue = props[col].GetValue(item);
                worksheet.Cell(row + 2, col + 1).Value = rawValue?.ToString() ?? string.Empty;
            }
        }

        var stream = new MemoryStream();
        workbook.SaveAs(stream);
        stream.Position = 0;
        return stream;
    }
}