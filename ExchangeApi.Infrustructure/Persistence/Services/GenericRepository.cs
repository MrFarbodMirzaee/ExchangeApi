using ExchangeApi.Application.Filters;
using ExchangeApi.Domain.Contracts;
using ExchangeApi.Domain.ValueObjects;
using ExchangeApi.Domain.Wrappers;
using ExchangeApi.Infrustructure.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace ExchangeApi.Infrustructure.Persistence.Services;
public class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : class
{
    protected readonly AppDbContext _applicationDbContext;
    public GenericRepository(AppDbContext applicationDbContext) => _applicationDbContext = applicationDbContext;
    public async Task<Response<List<TEntity>>> GetAllAsync(CancellationToken ct,int page, int pageSize)
    {
        var totalEntityCount = _applicationDbContext.Set<TEntity>().AsNoTracking().Count();

        var entityPerPage = await _applicationDbContext.Set<TEntity>()
                                                       .Skip((page -1) * pageSize)
                                                       .Take(pageSize)
                                                       .ToListAsync();
        
        if (!entityPerPage.Any())
            return new Response<List<TEntity>>("Something went wrong");

        return new Response<List<TEntity>>(entityPerPage);
    }
    public async Task<IEnumerable<TEntity>> FindByQueryCriterial(QueryCriterial queryCriteria, CancellationToken cancellationToken)
    {
        return await _applicationDbContext.Set<TEntity>().ApplyFilter(queryCriteria);
    }
    public async Task<Response<List<TEntity>>> FindByCondition(Expression<Func<TEntity, bool>> expression, CancellationToken ct)
    {
        var entities = await _applicationDbContext.Set<TEntity>().Where(expression).AsNoTracking().ToListAsync(ct);
        if (!entities.Any())
            return new Response<List<TEntity>>("Entity not fount");

        return new Response<List<TEntity>>(entities);
    }
    public async Task<Response<bool>> AddAsync(TEntity entity, CancellationToken ct)
    {
        try
        {
            _applicationDbContext.Set<TEntity>().Add(entity);

            var rowsAffected = await _applicationDbContext.SaveChangesAsync(ct);

            if (rowsAffected == 0)
                return new Response<bool>("Add failed: Unable to save the new record.");

            return new Response<bool>(true);
        }
        catch (DbUpdateException ex)
        {
            return new Response<bool>($"Add failed due to a database update error: {ex.Message}");
        }
        catch (Exception ex)
        {
            return new Response<bool>($"Add failed: {ex.Message}");
        }
    }
    public async Task<Response<bool>> UpdateAsync(TEntity entity, CancellationToken ct)
    {
        try
        {
            _applicationDbContext.Set<TEntity>().Update(entity);

            var rowsAffected = await _applicationDbContext.SaveChangesAsync(ct);

            if (rowsAffected == 0)
                return new Response<bool>("Update failed: The record may have been modified or deleted by another operation.");

            return new Response<bool>(true);
        }
        catch (DbUpdateConcurrencyException)
        {
            return new Response<bool>("Update failed due to a concurrency conflict: The record was likely modified or deleted by another operation.");
        }
        catch (Exception ex)
        {
            return new Response<bool>($"Update failed: {ex.Message}");
        }
    }
    public async Task<Response<bool>> DeleteAsync(TEntity entity, CancellationToken ct)
    {
        try
        {
            _applicationDbContext.Set<TEntity>().Remove(entity);

            var rowsAffected = await _applicationDbContext.SaveChangesAsync(ct);

            if (rowsAffected == 0)
                return new Response<bool>("Delete failed: The record may not exist or was already deleted.");

            return new Response<bool>(true);
        }
        catch (DbUpdateConcurrencyException)
        {
            return new Response<bool>("Delete failed due to a concurrency conflict: The record was likely modified or deleted by another operation.");
        }
        catch (Exception ex)
        {
            return new Response<bool>($"Delete failed: {ex.Message}");
        }
    }
}
