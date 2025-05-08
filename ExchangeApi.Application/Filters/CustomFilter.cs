using System.Globalization;
using ExchangeApi.Domain.ValueObjects;
using System.Linq.Expressions;
using System.Text.Json;
using ExchangeApi.Domain.Enums;

namespace ExchangeApi.Application.Filters;

public static class CustomFilter
{
    private static Expression<Func<T, bool>> GetFilterExpression<T>(Filter filter)
    {

    var parameter = Expression
            .Parameter(typeof(T), "x");
    
    var propertyInfo = typeof(T)
            .GetProperty(filter.PropertyName);
    
    var fieldInfo = typeof(T)
            .GetField(filter.PropertyName);
    
    if (propertyInfo == null && fieldInfo == null)
        throw new ArgumentException(
            $"Property or field '{filter.PropertyName}' not found on type '{typeof(T).Name}'.");

    var propExpr = Expression
            .PropertyOrField(parameter, filter.PropertyName);

    var targetType = propExpr.Type;
    
    if (targetType.IsGenericType && targetType.GetGenericTypeDefinition() == typeof(Nullable<>))
            targetType = Nullable.GetUnderlyingType(targetType)!;

    object rawValue = filter.Value!;
    
    if (rawValue is JsonElement je)
    {
        rawValue = je.ValueKind switch
        {
            JsonValueKind.String when targetType == typeof(Guid)   => Guid.Parse(je.GetString()!),
            JsonValueKind.String                                => je.GetString()!,
            JsonValueKind.Number when targetType == typeof(int)    => je.GetInt32(),
            JsonValueKind.Number when targetType == typeof(long)   => je.GetInt64(),
            JsonValueKind.Number when targetType == typeof(double) => je.GetDouble(),
            JsonValueKind.True  or JsonValueKind.False              => je.GetBoolean(),
            _ => throw new InvalidOperationException(
                    $"Cannot convert JSON value '{je.GetRawText()}' to {targetType.Name}")
        };
    }

    var converted = Convert
            .ChangeType(rawValue, targetType, CultureInfo.InvariantCulture);

    var constExpr = Expression
            .Constant(converted, propExpr.Type);

    Expression body = filter.Operation switch
    {
        Operator.Eq     => Expression.Equal(propExpr, constExpr),
        Operator.NotEq  => Expression.NotEqual(propExpr, constExpr),
        Operator.Gt     => Expression.GreaterThan(propExpr, constExpr),
        Operator.GtOrEq => Expression.GreaterThanOrEqual(propExpr, constExpr),
        Operator.Lt     => Expression.LessThan(propExpr, constExpr),
        Operator.LtOrEq => Expression.LessThanOrEqual(propExpr, constExpr),
        Operator.Contains when propExpr.Type == typeof(string) =>
            Expression.Call(propExpr,
                typeof(string).GetMethod(nameof(string.Contains), new[] { typeof(string) })!,
                constExpr),
        _ => throw new InvalidOperationException(
                $"Unsupported filter operation '{filter.Operation}' for property '{filter.PropertyName}'")
    };

    return Expression
        .Lambda<Func<T, bool>>(body, parameter);
    }

    private static Expression<Func<T, object>> GetSortExpression<T>(Sort sort)
    {
        
        var prop = Expression
                    .Parameter(typeof(T));
        
        var property = Expression
                    .PropertyOrField(prop, sort.PropertyName);
        
        return Expression
                    .Lambda<Func<T, object>>(property, prop);
    }

    public static IQueryable<T> ApplyFilter<T>(this IQueryable<T> query, QueryCriteria? queryCriteria)
    {
        if (queryCriteria is not null)
        {
            if (queryCriteria.Filters is not null && !queryCriteria.Filters!
                    .Any(s=> s.PropertyName
                        .Equals("string",StringComparison.OrdinalIgnoreCase)))
                foreach (var filter in queryCriteria.Filters)
                    query = query
                        .Where(GetFilterExpression<T>(filter));

            if (queryCriteria.Sorts is not null && queryCriteria
                    .Sorts.Any() && !queryCriteria.Sorts
                        .Any(s=> s.PropertyName
                            .Equals("string",StringComparison.OrdinalIgnoreCase) ) )
            {
                var first = queryCriteria
                        .Sorts
                        .First();
                
                var ord = first.IsAscending
                    ? query
                        .OrderBy(GetSortExpression<T>(first))
                    : query
                        .OrderByDescending(GetSortExpression<T>(first));

                foreach (var s in queryCriteria.Sorts.Skip(1))
                    ord = s.IsAscending
                        ? ord
                            .ThenBy(GetSortExpression<T>(s))
                        : ord
                            .ThenByDescending(GetSortExpression<T>(s));

                query = ord;
            }

            var skip = queryCriteria.Skip  >= 0 ? queryCriteria.Skip  : 0;
            var take = queryCriteria.Take  >  0 ? queryCriteria.Take  : int.MaxValue;

            query = query
                .Skip(skip)
                .Take(take);
        }

        return query;
    }
}