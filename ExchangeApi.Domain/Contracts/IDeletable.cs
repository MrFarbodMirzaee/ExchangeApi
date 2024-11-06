namespace ExchangeApi.Domain.Contracts;
public interface IDeletable
{
    public int DeletedByUserId { get; set; }
    public DateTime Created { get; set; }
}
