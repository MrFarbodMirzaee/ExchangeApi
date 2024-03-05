namespace ExChangeApi.Contract;

public interface IBaseEntity<T>
{
    T Id { get; set; }
    DateTime Created { get; set; }
    bool IsActive { get; set; }
}
