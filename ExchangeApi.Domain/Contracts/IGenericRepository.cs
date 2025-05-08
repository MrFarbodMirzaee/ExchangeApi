using ExchangeApi.Domain.ValueObjects;
using ExchangeApi.Domain.Wrappers;
using System.Linq.Expressions;

namespace ExchangeApi.Domain.Contracts;

public interface IGenericRepository<TEntity> where TEntity : class
{
    Task<Response<IEnumerable<TEntity>>> FindByQueryCriteria(QueryCriteria? queryCriteria, CancellationToken ct);
    Task<Response<List<TEntity>>> FindByCondition(Expression<Func<TEntity, bool>> expression, CancellationToken ct);
    Task<Response<bool>> AddAsync(TEntity entity, CancellationToken ct);
    Task<Response<bool>> UpdateAsync(TEntity entity, CancellationToken ct);
    Task<Response<bool>> DeleteAsync(TEntity entity, CancellationToken ct);
}