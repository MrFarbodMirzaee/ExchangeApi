namespace ExchangeApi.Domain.Contracts;

public interface IAuditable
{
    public int UpdatedByUserId { get; set; }
    public DateTime Updated { get; set; }
}
