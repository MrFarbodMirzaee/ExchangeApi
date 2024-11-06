namespace ExchangeApi.Domain.Contracts;
public interface IBaseEntity<T>
{
    public T Id { get; set; }
    public string MetaDescription { get; set; }
    public string Description { get; set; }
    public DateTime Created { get; set; }
    public DateTime Updated { get; set; }
}
