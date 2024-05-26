using ExchangeApi.Domain.Wrappers;
using System.Linq.Expressions;

namespace ExchangeApi.Domain.Contracts;

public interface IGenericRepository<TEntity> where TEntity : class
{
    Task<Response<List<TEntity>>> GetAllAsync();
    Task<Response<List<TEntity>>> FindByCondition(Expression<Func<TEntity,bool>>expression);
    Task<Response<bool>> AddAsync(TEntity entity);
    Task<Response<bool>> UpdateAsync(TEntity entity);
    Task<Response<bool>> DeleteAsync(TEntity entity);
}
