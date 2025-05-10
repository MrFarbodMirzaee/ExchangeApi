namespace ExchangeApi.Application.Dtos;

public record ExcelFileResponseDto(
    int RowCount,
    int ColumnCount,
    List<List<string>> Data,
    List<string>? Headers = null,
    string? SheetName = null
);