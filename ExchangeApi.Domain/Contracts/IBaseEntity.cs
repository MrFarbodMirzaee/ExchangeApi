namespace ExchangeApi.Domain.Contracts;

public interface IBaseEntity<T>
{
    T Id { get; set; }
    DateTime Created { get; set; }
    DateTime Updated { get; set; }
    bool IsActive { get; set; }
}
