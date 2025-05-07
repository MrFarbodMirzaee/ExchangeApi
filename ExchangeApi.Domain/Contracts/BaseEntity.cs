namespace ExchangeApi.Domain.Contracts;

public abstract class BaseEntity<T>
{
    public T Id { get; set; }
    public string MetaDescription { get; set; }
    public DateTime Created { get; set; }
    public DateTime Updated { get; set; }
}