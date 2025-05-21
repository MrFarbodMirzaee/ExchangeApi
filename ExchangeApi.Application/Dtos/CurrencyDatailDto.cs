namespace ExchangeApi.Application.Dtos;

public record CurrencyDatailDto(
string CurrencyCode,
string Name,
bool IsActive,
string ImagePath ,
string Description,
ICollection<DownloadFileDto> Files,
ICollection<CurrencyAttributeDto> CurrencyAttributes,
CategoryDto Category
);