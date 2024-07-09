using ExchangeApi.Application.Filters;
using ExchangeApi.Domain.Contracts;
using ExchangeApi.Domain.ValueObjects;
using ExchangeApi.Domain.Wrappers;
using ExchangeApi.Infrustructure.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace ExchangeApi.Infrustructure.Persistence.Services;

public class GengericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : class
{
    protected readonly ApplicationDbContext _dbContext;
    public GengericRepository(ApplicationDbContext context) 
    {
        _dbContext = context;
    }
    public async Task<Response<bool>> AddAsync(TEntity entity, CancellationToken ct)
    {
        await _dbContext.Set<TEntity>().AddAsync(entity);
        await _dbContext.SaveChangesAsync(ct);
        return new Response<bool>(true);
    }

    public async Task<Response<bool>> DeleteAsync(TEntity entity, CancellationToken ct)
    {
         _dbContext.Set<TEntity>().Remove(entity);
        await _dbContext.SaveChangesAsync(ct);
        return new Response<bool>(true);
    }

    public async Task<Response<List<TEntity>>> FindByCondition(Expression<Func<TEntity, bool>> expression, CancellationToken ct)
    {
          var entities = await _dbContext.Set<TEntity>().Where(expression).AsNoTracking().ToListAsync(ct);
        return new Response<List<TEntity>>(entities);
    }

    public async Task<IEnumerable<TEntity>> FindByQueryCriterial(QueryCriterial queryCriteria,CancellationToken cancellationToken)
    {
        return await _dbContext.Set<TEntity>().ApplyFilter(queryCriteria);
    }

    public async Task<Response<List<TEntity>>> GetAllAsync(CancellationToken ct)
    {
        var entities = await _dbContext.Set<TEntity>().AsNoTracking().ToListAsync(ct);
        return new Response<List<TEntity>>(entities);
    }

    public async Task<Response<bool>> UpdateAsync(TEntity entity, CancellationToken ct)
    {
         _dbContext.Set<TEntity>().Update(entity);
        await _dbContext.SaveChangesAsync(ct);
        return new Response<bool>(true);
    }
}
