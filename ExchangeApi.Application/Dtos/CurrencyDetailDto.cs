namespace ExchangeApi.Application.Dtos;

public record CurrencyDetailDto(
string CurrencyCode,
string Name,
bool IsActive,
string ImagePath ,
string Description,
ICollection<DownloadFileDto> Files,
ICollection<CurrencyAttributeDto> CurrencyAttributes,
CategoryDto Category
);