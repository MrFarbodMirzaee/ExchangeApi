namespace ExchangeApi.Domain.Contracts;

public interface IAuditable
{
    public Guid UpdatedByUserId { get; set; }
    public DateTime Updated { get; set; }
}