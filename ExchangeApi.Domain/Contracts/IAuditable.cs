namespace ExchangeApi.Domain.Contracts;

public interface IAuditable
{
    public Guid UpdatedByUserId { get; set; }
    public DateTimeOffset Updated { get; set; }
}