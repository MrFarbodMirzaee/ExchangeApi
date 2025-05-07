using System.Reflection;
using ExchangeApi.Domain.Contracts;
using Microsoft.EntityFrameworkCore;

namespace ExchangeApi.Infrastructure.Extensions;

public static class ModelBuilderExtensions
{
    public static ModelBuilder RegisterAllEntities(this ModelBuilder modelBuilder, params Assembly[] assemblies)
    {
        IEnumerable<Type> types = assemblies
                                 .SelectMany(a => 
                                    a.GetExportedTypes())
            .Where(t =>
                t is { IsClass: true, IsAbstract: false, IsPublic: true } &&
                Attribute
                 .IsDefined(t, typeof(EntityAttribute)));

        foreach (Type type in types)
            modelBuilder.Entity(type);

        return modelBuilder;
    }
}