using ExchangeApi.Domain.ValueObjects;
using System.Linq.Expressions;
using ExchangeApi.Domain.Enums;

namespace ExchangeApi.Application.Filters;

public static class CustomFilter
{
    private static Expression<Func<T, bool>> GetFilterExpression<T>(Filter filter)
    {
        var parameter = Expression.Parameter(typeof(T));

        var propName = Expression.PropertyOrField(parameter, filter.PropertyName);
        var targetType = propName.Type;
        if (targetType.IsGenericType && targetType.GetGenericTypeDefinition() == typeof(Nullable<>))
            targetType = Nullable.GetUnderlyingType(targetType);
        var constExpression = Expression.Constant(Convert.ChangeType(filter.Value, targetType), propName.Type);
        Expression filterExpression;

        switch (filter.Operation)
        {
            case Operator.Eq:
                filterExpression = Expression.Equal(propName, constExpression);
                break;
            case Operator.LtOrEQ:
                filterExpression = Expression.LessThanOrEqual(propName, constExpression);
                break;
            case Operator.Lt:
                filterExpression = Expression.LessThan(propName, constExpression);
                break;
            case Operator.Gt:
                filterExpression = Expression.GreaterThan(propName, constExpression);
                break;
            case Operator.GtOrEQ:
                filterExpression = Expression.GreaterThanOrEqual(propName, constExpression);
                break;
            case Operator.NotEq:
                filterExpression = Expression.NotEqual(propName, constExpression);
                break;
            case Operator.Contains:
                var ContainsMethodInfo = typeof(string).GetMethod(nameof(string.Contains), new Type[] { typeof(string) });
                filterExpression = Expression.Call(propName, ContainsMethodInfo, constExpression);
                break;
            default:
                throw new InvalidOperationException();
        }
        return Expression.Lambda<Func<T, bool>>(filterExpression, parameter);
    }

    private static Expression<Func<T, object>> GetSortExpression<T>(Sort sort)

    {
        var prop = Expression.Parameter(typeof(T));
        var property = Expression.PropertyOrField(prop, sort.PropertyName);
        return Expression.Lambda<Func<T, object>>(property, prop);
    }
    public async static Task<IEnumerable<T>> ApplyFilter<T>(this IQueryable<T> query, QueryCriterial queryCriterial)
    {
        if (queryCriterial is not null)
        {
            if (queryCriterial.Filters is not null)
            {
                foreach (var filter in queryCriterial.Filters)
                {
                    query = query.Where(GetFilterExpression<T>(filter));
                }
            }

            if (queryCriterial.Sorts is not null)
            {
                foreach (var sort in queryCriterial.Sorts)
                {
                    query = sort.IsAscending ?
                        query.OrderBy(GetSortExpression<T>(sort)) :
                        query.OrderByDescending(GetSortExpression<T>(sort));
                }
            }

            return query.Skip(queryCriterial.Skip)
                        .Take(queryCriterial.Take)
                        .ToList();
        }
        else
        {
            return query.ToList();
        }
    }

}
