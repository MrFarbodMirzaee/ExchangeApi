using System.Linq.Expressions;
using ExchangeApi.Application.Filters;
using ExchangeApi.Domain.Contracts;
using ExchangeApi.Domain.ValueObjects;
using ExchangeApi.Domain.Wrappers;
using ExchangeApi.Infrastructure.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;
using ResourceApi.Messages;

namespace ExchangeApi.Infrastructure.Persistence.Services;

public class GenericRepository<TEntity>(AppDbContext applicationDbContext) : IGenericRepository<TEntity>
    where TEntity : class
{
    public async Task<Response<IEnumerable<TEntity>>> FindByQueryCriteria(QueryCriteria? queryCriteria,
        CancellationToken cancellationToken)
    {
        var query = applicationDbContext
            .Set<TEntity>()
            .AsQueryable();

        if (queryCriteria != null)
            query = query
            .ApplyFilter(queryCriteria);


        var entities = await query
            .ToListAsync(cancellationToken);

        if (!entities.Any())
        {
            return new Response
                <IEnumerable<TEntity>>
                (Validations.NoDataFoundEntity,typeof(TEntity).Name);
        }

        return new Response
            <IEnumerable<TEntity>>
            (entities);
    }

    public async Task<Response<List<TEntity>>> FindByCondition(Expression<Func<TEntity, bool>> expression,
        CancellationToken ct)
    {
        var entities = await applicationDbContext
            .Set<TEntity>()
            .Where(expression)
            .AsNoTracking()
            .ToListAsync(ct);

        if (!entities.Any())
            return new 
                Response<List<TEntity>>
                (Validations.NoDataFoundEntity,typeof(TEntity).Name);

        return new 
            Response<List<TEntity>>
            (entities);
    }

    public async Task<Response<bool>> AddAsync(TEntity entity, CancellationToken ct)
    {
        applicationDbContext
            .Set<TEntity>()
            .Add(entity);

        var rowsAffected = await
            applicationDbContext
            .SaveChangesAsync(ct);

        return new
            Response<bool>
            (true);
    }

    public async Task<Response<bool>> UpdateAsync(TEntity entity, CancellationToken ct)
    {
            applicationDbContext
                .Set<TEntity>()
                .Update(entity);

            var rowsAffected = await 
                applicationDbContext
                .SaveChangesAsync(ct);

            if (rowsAffected == 0)
                return new 
                    Response<bool>
                    (Validations.UpdateFailed);

            return new 
                Response<bool>
                (true);
    }

    public async Task<Response<bool>> DeleteAsync(TEntity entity, CancellationToken ct)
    {
            applicationDbContext
                .Set<TEntity>()
                .Remove(entity);

            var rowsAffected = await 
                applicationDbContext
                .SaveChangesAsync(ct);

            if (rowsAffected == 0)
                return new
                    Response<bool>
                    (Validations.NoDataFoundEntity);

            return new 
                Response<bool>
                (true);
    }
}