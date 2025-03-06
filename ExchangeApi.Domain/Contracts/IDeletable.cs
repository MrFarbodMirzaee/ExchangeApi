namespace ExchangeApi.Domain.Contracts;

public interface IDeletable
{
    public Guid DeletedByUserId { get; set; }
    public DateTime Created { get; set; }
}