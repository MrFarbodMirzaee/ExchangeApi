namespace ExchangeApi.Domain.Contracts;

public interface IBaseEntity<T>
{
    T Id { get; set; }
    string MetaDescription { get; set; }
    string Description { get; set; }
    DateTime Created { get; set; }
    DateTime Updated { get; set; }
}
