namespace ExchangeApi.Application.Dtos;

public record UserDetailDto(
     string Name,
     string UserName,
     string EmailAddress,
     string Password,
     bool IsActive,
     string Description,
     ICollection<ExchangeTransactionDto> ExchangeTransactions,
     ICollection<DownloadFileDto>? Files
);
