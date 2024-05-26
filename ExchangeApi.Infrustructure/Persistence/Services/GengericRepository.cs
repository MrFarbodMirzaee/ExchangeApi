using ExchangeApi.Domain.Contracts;
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
    public async Task<Response<bool>> AddAsync(TEntity entity)
    {
        await _dbContext.Set<TEntity>().AddAsync(entity);
        await _dbContext.SaveChangesAsync();
        return new Response<bool>(true);
    }

    public async Task<Response<bool>> DeleteAsync(TEntity entity)
    {
         _dbContext.Set<TEntity>().Remove(entity);
        await _dbContext.SaveChangesAsync();
        return new Response<bool>(true);
    }

    public async Task<Response<List<TEntity>>> FindByCondition(Expression<Func<TEntity, bool>> expression)
    {
          var entities = await _dbContext.Set<TEntity>().Where(expression).AsNoTracking().ToListAsync();
        return new Response<List<TEntity>>(entities);
    }

    public async Task<Response<List<TEntity>>> GetAllAsync()
    {
        var entities = await _dbContext.Set<TEntity>().AsNoTracking().ToListAsync();
        return new Response<List<TEntity>>(entities);
    }

    public async Task<Response<bool>> UpdateAsync(TEntity entity)
    {
         _dbContext.Set<TEntity>().Update(entity);
        await _dbContext.SaveChangesAsync();
        return new Response<bool>(true);
    }
}
