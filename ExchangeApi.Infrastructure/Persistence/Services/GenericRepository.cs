using System.Linq.Expressions;
using ExchangeApi.Application.Filters;
using ExchangeApi.Domain.Contracts;
using ExchangeApi.Domain.ValueObjects;
using ExchangeApi.Domain.Wrappers;
using ExchangeApi.Infrastructure.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;

namespace ExchangeApi.Infrastructure.Persistence.Services;

public class GenericRepository<TEntity>(AppDbContext applicationDbContext) : IGenericRepository<TEntity>
    where TEntity : class
{
    public async Task<Response<List<TEntity>>> GetAllAsync(CancellationToken ct, int page, int pageSize)
    {
        var entityPerPage = await applicationDbContext.Set<TEntity>()
            .Skip(Math.Max(0, (page - 1) * pageSize))
            .Take(pageSize)
            .ToListAsync(ct);

        if (!entityPerPage.Any())
            return new Response<List<TEntity>>("Something went wrong");

        return new Response<List<TEntity>>(entityPerPage);
    }

    public async Task<IEnumerable<TEntity>> FindByQueryCriteria(QueryCriteria? queryCriteria,
        CancellationToken cancellationToken)
    {
        return await applicationDbContext.Set<TEntity>().ApplyFilter(queryCriteria);
    }

    public async Task<Response<List<TEntity>>> FindByCondition(Expression<Func<TEntity, bool>> expression,
        CancellationToken ct)
    {
        var entities = await applicationDbContext.Set<TEntity>().Where(expression).AsNoTracking().ToListAsync(ct);
        if (!entities.Any())
            return new Response<List<TEntity>>("Entity not found");

        return new Response<List<TEntity>>(entities);
    }

    public async Task<Response<bool>> AddAsync(TEntity entity, CancellationToken ct)
    {
        try
        {
            applicationDbContext.Set<TEntity>().Add(entity);

            var rowsAffected = await applicationDbContext.SaveChangesAsync(ct);

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
            applicationDbContext.Set<TEntity>().Update(entity);

            var rowsAffected = await applicationDbContext.SaveChangesAsync(ct);

            if (rowsAffected == 0)
                return new Response<bool>(
                    "Update failed: The record may have been modified or deleted by another operation.");

            return new Response<bool>(true);
        }
        catch (DbUpdateConcurrencyException)
        {
            return new Response<bool>(
                "Update failed due to a concurrency conflict: The record was likely modified or deleted by another operation.");
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
            applicationDbContext.Set<TEntity>().Remove(entity);

            var rowsAffected = await applicationDbContext.SaveChangesAsync(ct);

            if (rowsAffected == 0)
                return new Response<bool>("Delete failed: The record may not exist or was already deleted.");

            return new Response<bool>(true);
        }
        catch (DbUpdateConcurrencyException)
        {
            return new Response<bool>(
                "Delete failed due to a concurrency conflict: The record was likely modified or deleted by another operation.");
        }
        catch (Exception ex)
        {
            return new Response<bool>($"Delete failed: {ex.Message}");
        }
    }
}