namespace ExchangeApi.Application.Dtos;

public record CurrencyAttributeDto(
string Key,
string Value,
bool IsActive ,
string Description 
);