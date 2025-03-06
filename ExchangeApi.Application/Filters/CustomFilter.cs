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
        var constExpression =
            Expression.Constant(Convert.ChangeType(filter.Value, targetType ?? throw new InvalidOperationException()),
                propName.Type);
        Expression filterExpression;

        switch (filter.Operation)
        {
            case Operator.Eq:
                filterExpression = Expression.Equal(propName, constExpression);
                break;
            case Operator.LtOrEq:
                filterExpression = Expression.LessThanOrEqual(propName, constExpression);
                break;
            case Operator.Lt:
                filterExpression = Expression.LessThan(propName, constExpression);
                break;
            case Operator.Gt:
                filterExpression = Expression.GreaterThan(propName, constExpression);
                break;
            case Operator.GtOrEq:
                filterExpression = Expression.GreaterThanOrEqual(propName, constExpression);
                break;
            case Operator.NotEq:
                filterExpression = Expression.NotEqual(propName, constExpression);
                break;
            case Operator.Contains:
                var containsMethodInfo =
                    typeof(string).GetMethod(nameof(string.Contains), new Type[] { typeof(string) });
                filterExpression = Expression.Call(propName, containsMethodInfo, constExpression);
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

    public async static Task<IEnumerable<T>> ApplyFilter<T>(this IQueryable<T> query, QueryCriteria? queryCriteria)
    {
        if (queryCriteria is not null)
        {
            if (queryCriteria.Filters is not null)
            {
                foreach (var filter in queryCriteria.Filters)
                {
                    query = query.Where(GetFilterExpression<T>(filter));
                }
            }

            if (queryCriteria.Sorts is not null)
            {
                foreach (var sort in queryCriteria.Sorts)
                {
                    query = sort.IsAscending
                        ? query.OrderBy(GetSortExpression<T>(sort))
                        : query.OrderByDescending(GetSortExpression<T>(sort));
                }
            }

            return query.Skip(queryCriteria.Skip)
                .Take(queryCriteria.Take)
                .ToList();
        }
        else
        {
            return query.ToList();
        }
    }
}