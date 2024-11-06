namespace ExchangeApi.Application.Dtos;

public record DownloadFileDto(string FileName, string ContentType, byte[] FileData);

