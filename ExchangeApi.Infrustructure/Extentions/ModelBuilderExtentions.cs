using ExchangeApi.Domain.Contracts;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace ExchangeApi.Infrustructure.Extentions;
public static class ModelBuilderExtentions
{
    public static ModelBuilder RegisterAllEntities(this ModelBuilder modelBuilder, params Assembly[] assemblies)
    {
        IEnumerable<Type> types = assemblies.SelectMany(a => a.GetExportedTypes())
            .Where(t =>
                t is { IsClass: true, IsAbstract: false, IsPublic: true } &&
                Attribute.IsDefined(t, typeof(EntityAttribute)));

        foreach (Type type in types)
            modelBuilder.Entity(type);

        return modelBuilder;
    }
}
