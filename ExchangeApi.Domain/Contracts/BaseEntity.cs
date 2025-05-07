namespace ExchangeApi.Domain.Contracts;

public abstract class BaseEntity<T>
{
    public T Id { get; set; }
    public string MetaDescription { get; set; }
    public DateTimeOffset Created { get; set; }
    public DateTimeOffset Updated { get; set; }
}